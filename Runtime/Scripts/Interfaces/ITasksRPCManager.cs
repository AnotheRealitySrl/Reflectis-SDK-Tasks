namespace Reflectis.PLG.Tasks
{
    public interface ITasksRPCManager
    {
        public void UpdateTasksID(int id);
        public void RPC_TaskStatusChanged(int taskID);

        public void SendRPCTaskStatusChange(int taskID);
    }
}
