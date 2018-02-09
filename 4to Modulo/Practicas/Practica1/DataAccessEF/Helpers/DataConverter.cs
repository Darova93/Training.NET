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
                Description = dtoObject.Description
            };
        }

        public static QuestionTypeDTO QuestionTypeEntityToDTO(QuestionType entityObject)
        {
            return new QuestionTypeDTO
            {
                QuestionTypeId = entityObject.QuestionTypeId,
                Description = entityObject.Description
            };
        }

        public static QuestionDTO QuestionEntityToDTO(Question entityObject)
        {
            return new QuestionDTO
            {
                QuestionId = entityObject.QuestionId,
                Text = entityObject.Text,
                QuestionTypeId = entityObject.QuestionTypeId,
            };
        }

        public static Question QuestionDTOToEntity(QuestionDTO DTOObject)
        {
            return new Question
            {
                QuestionId = DTOObject.QuestionId,
                Text = DTOObject.Text,
                QuestionTypeId = DTOObject.QuestionTypeId,
            };
        }

        public static Option OptionDTOToEntity(Option DTOObject)
        {
            return new Option
            {
                OptionId = DTOObject.OptionId,
                Text = DTOObject.Text
            };
        }

        public static OptionDTO OptionEntityToDTO(Option entityObject)
        {
            return new OptionDTO
            {
                OptionId = entityObject.OptionId,
                Text = entityObject.Text
            };
        }
    }
}
