using DataAccessEF.Entities;
using DTO.DTO;

namespace DataAccessEF.Helpers
{
    public class DataConverter
    {
        public static QuestionType QuestionTypeDTOToEntity(QuestionTypeDTO dtoObject)
        {
            return new QuestionType
            {
                QuestionTypeId = dtoObject.QuestionTypeId,
                Description = dtoObject.Description,
                CreateDate = dtoObject.CreateDate
            };
        }

        public static QuestionTypeDTO QuestionTypeEntityToDTO(QuestionType entityObject)
        {
            return new QuestionTypeDTO
            {
                QuestionTypeId = entityObject.QuestionTypeId,
                Description = entityObject.Description,
                CreateDate = entityObject.CreateDate
            };
        }

        public static QuestionDTO QuestionEntityToDTO(Question entityObject)
        {
            return new QuestionDTO
            {
                QuestionId = entityObject.QuestionId,
                Text = entityObject.Text,
                QuestionTypeId = entityObject.QuestionTypeId,
                IsActive = entityObject.IsActive,
                IsRequired = entityObject.IsRequired,
                CreateDate = entityObject.CreateDate,
                ModifiedDate = entityObject.ModifiedDate
            };
        }

        public static Question QuestionDTOToEntity(QuestionDTO DTOObject)
        {
            return new Question
            {
                QuestionId = DTOObject.QuestionId,
                Text = DTOObject.Text,
                QuestionTypeId = DTOObject.QuestionTypeId,
                IsActive = DTOObject.IsActive,
                IsRequired = DTOObject.IsRequired,
                CreateDate = DTOObject.CreateDate,
                ModifiedDate = DTOObject.ModifiedDate
            };
        }

        public static Option OptionDTOToEntity(OptionDTO DTOObject)
        {
            return new Option
            {
                OptionId = DTOObject.OptionId,
                Text = DTOObject.Text,
                CreateDate = DTOObject.CreateDate,
                ModifiedDate = DTOObject.ModifiedDate
            };
        }

        public static OptionDTO OptionEntityToDTO(Option entityObject)
        {
            return new OptionDTO
            {
                OptionId = entityObject.OptionId,
                Text = entityObject.Text,
                CreateDate = entityObject.CreateDate,
                ModifiedDate = entityObject.ModifiedDate
            };
        }
    }
}
