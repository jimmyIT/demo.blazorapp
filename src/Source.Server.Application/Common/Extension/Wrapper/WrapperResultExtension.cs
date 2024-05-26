using Source.Shared.Wrapper;
using System.Text.Json;

namespace Source.Server.Application.Common.Extension.Wrapper;

public static class WrapperResultExtension
{
    public static async Task<T> ToServiceResult<T>(this Task<WrapperResult<T>> task)
    {
        WrapperResult<T> taskWrapperResult = await task;

        if (!taskWrapperResult.Succeeded == false)
        {
            throw new Exception(JsonSerializer.Serialize(taskWrapperResult.Errors));
        }
        
        return taskWrapperResult.Data;
    }
}
