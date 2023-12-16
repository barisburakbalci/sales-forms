using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Answer, CreateAnswerVM>().ReverseMap();
            CreateMap<Answer, UpdateAnswerVM>().ReverseMap();

            CreateMap<Folder, CreateFolderVM>().ReverseMap();
            CreateMap<Folder, UpdateFolderVM>().ReverseMap();

            CreateMap<Form, CreateFormVM>().ReverseMap();
            CreateMap<Form, UpdateFormVM>().ReverseMap();

            CreateMap<Option, CreateOptionVM>().ReverseMap();
            CreateMap<Option, UpdateOptionVM>().ReverseMap();

            CreateMap<Participant, CreateParticipantVM>().ReverseMap();
            CreateMap<Participant, UpdateParticipantVM>().ReverseMap();

            CreateMap<Question, CreateQuestionVM>().ReverseMap();
            CreateMap<Question, UpdateQuestionVM>().ReverseMap();
        }
    }
}
