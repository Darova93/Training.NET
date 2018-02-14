using DataAccess.Entities;
using DTO.DTO;

namespace DataAccess.Helpers
{
    public class DataConverter
    {
        public static TaskEF ConvertTaskDTOtoEntity (TaskDTO DTOTask)
        {
            TaskEF EntityTask = new TaskEF
            {
                TaskId = DTOTask.TaskId,
                Title = DTOTask.Title,
                Description = DTOTask.Description,
                Priority = DTOTask.Priority,
                DueDate = DTOTask.DueDate,
                IsArchived  = DTOTask.IsArchived,
                Status = DTOTask.Status,
                CreateDate = DTOTask.CreateDate
            };
            return EntityTask;
        }

        public static TaskDTO ConvertTaskEntitytoDTO(TaskEF EFTask)
        {
            TaskDTO DTOTask = new TaskDTO
            {
                TaskId = EFTask.TaskId,
                Title = EFTask.Title,
                Description = EFTask.Description,
                Priority = EFTask.Priority,
                DueDate = EFTask.DueDate,
                IsArchived = EFTask.IsArchived,
                Status = EFTask.Status,
                CreateDate = EFTask.CreateDate
            };
            return DTOTask;
        }

        public static TagEF ConvertTagDTOtoEntity(TagDTO DTOTag)
        {
            TagEF EFTag = new TagEF
            {
                TagId = DTOTag.TagId,
                Description = DTOTag.Description,
                IsArchived = DTOTag.IsArchived,
                CreateDate = DTOTag.CreateDate
            };
            return EFTag;
        }

        public static TagDTO ConvertTagEntitytoDTO(TagEF EFTag)
        {
            TagDTO DTOTag = new TagDTO
            {
                TagId = EFTag.TagId,
                Description = EFTag.Description,
                IsArchived = EFTag.IsArchived,
                CreateDate = EFTag.CreateDate
            };
            return DTOTag;
        }
    }
}
