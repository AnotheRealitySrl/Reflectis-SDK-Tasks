using UnityEditor;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Reflectis.SDK.Tasks.UI
{
    /// <summary>
    /// Helps with the VideoPlayer and its RenderTexture.
    /// </summary>
    [RequireComponent(typeof(VideoPlayer))]
    public class TasksUIVideoController : MonoBehaviour
    {
        [SerializeField, Tooltip("Texture for the video Player and the raw Image")]
        private RenderTexture texture;

        [SerializeField, Tooltip("Name for the auto-created texture")]
        private string sampleTextureName = "SampleTexture";

        /// <summary>
        /// The <see cref="VideoPlayer"/> component attached to this GameObject.
        /// </summary>
        private VideoPlayer videoPlayer = default;
        private RawImage rawImage;
        private string sampleTextureFolderPath = "Assets/ReflectisSettings";

        ///////////////////////////////////////////////////////////////////////////
        private void Awake()
        {
            // Stores the VideoPlayer reference in the field.
            if (videoPlayer == null) videoPlayer = GetComponent<VideoPlayer>();
        }

        ///////////////////////////////////////////////////////////////////////////
        private void OnDisable()
        {
            // Resets the RenderTexture to black.
            videoPlayer.targetTexture.Release();
        }

        ///////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Check if the component need the render texture
        /// </summary>
        private void OnValidate()
        {
#if UNITY_EDITOR
            if (videoPlayer == null) videoPlayer = GetComponent<VideoPlayer>();
            if (rawImage == null) rawImage = GetComponentInChildren<RawImage>();

            //If there are the correct references, return
            if (videoPlayer.targetTexture != null && rawImage.texture != null && texture != null
                && videoPlayer.targetTexture == texture && rawImage.texture == texture)
                return;


            if (!AssetDatabase.IsValidFolder(sampleTextureFolderPath))
            {
                //Create the folder for the sample texture
                AssetDatabase.CreateFolder("Assets", "ReflectisSettings");
            }
            if (texture == null)
            {
                string texturePath = $"{sampleTextureFolderPath}/{sampleTextureName}.asset";

                //If we create the texture before, we use that and not create a new one
                RenderTexture sampleTexture = (RenderTexture)AssetDatabase.LoadAssetAtPath(texturePath, typeof(RenderTexture));
                if (sampleTexture != null)
                {
                    texture = sampleTexture;
                }
                else
                {
                    //Create the texture runtime
                    texture = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32)
                    {
                        name = sampleTextureName
                    };
                    texture.Create();
                    AssetDatabase.CreateAsset(texture, texturePath);
                }
            }

            //Assign the references
            videoPlayer.targetTexture = texture;
            rawImage.texture = texture;
#endif
        }
    }
}