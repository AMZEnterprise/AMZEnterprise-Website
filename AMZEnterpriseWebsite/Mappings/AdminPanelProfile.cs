using AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels;
using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Mappings.Resolvers;
using AutoMapper;

namespace AMZEnterpriseWebsite.Mappings
{
    public class AdminPanelProfile : Profile
    {
        public AdminPanelProfile()
        {
            //Certificate mappings
            CreateMap<Certificate, CertificateIndexViewModel>();
            CreateMap<Certificate, CertificateFormViewModel>()
                .ForMember(x => x.FilePath,
                    y =>
                        y.MapFrom<CertificateFormViewModelFilePathResolver>());
            CreateMap<CertificateFormViewModel, Certificate>();

            //Contact mappings
            CreateMap<Contact, ContactIndexViewModel>();
            CreateMap<Contact, ContactFormViewModel>();
            CreateMap<ContactFormViewModel, Contact>();

            //Post mapping
            CreateMap<Post, PostIndexViewModel>()
                .ForMember(x => x.UserFullName,
                    y =>
                        y.MapFrom<PostIndexViewModelUserFullNameResolver>());
            CreateMap<Post, PostFormViewModel>()
                .ForMember(x => x.UserFullName,
                    y =>
                        y.MapFrom<PostFormUserFullNameResolver>())
                .ForMember(x => x.FilePath,
                    y =>
                        y.MapFrom<PostFormViewModelFilePathResolver>());
            CreateMap<PostFormViewModel, Post>();


            //ProgressBar mappings
            CreateMap<ProgressBar, ProgressBarFormViewModel>();
            CreateMap<ProgressBarFormViewModel, ProgressBar>();

            //PostCategory mappings
            CreateMap<PostCategory, PostCategoryIndexViewModel>();
            CreateMap<PostCategory, PostCategoryFormViewModel>();
            CreateMap<PostCategoryFormViewModel, PostCategory>();

            //PostComment mappings
            CreateMap<PostComment, PostCommentIndexViewModel>()
                .ForMember(x => x.UserFullName,
                    y =>
                        y.MapFrom<PostCommentIndexViewModelUserFullNameResolver>())
                .ForMember(x => x.Status,
                    y =>
                        y.MapFrom(u => u.PostCommentStatus));
            CreateMap<PostComment, PostCommentFormViewModel>()
                .ForMember(x => x.Status,
                    y =>
                        y.MapFrom(u => u.PostCommentStatus));
            CreateMap<PostCommentFormViewModel, PostComment>()
                .ForMember(x => x.PostCommentStatus,
                    y =>
                        y.MapFrom(u => u.Status));
            CreateMap<PostComment, PostCommentReplyFormViewModel>()
                .ForMember(x => x.ParentId,
                    y =>
                        y.MapFrom(u => u.Id))
                .ForMember(x => x.PostId,
                    y =>
                        y.MapFrom(u => u.PostId))
                .ForMember(x => x.ParentBody,
                    y =>
                        y.MapFrom(u => u.Body))
                .ForMember(x => x.Body,
                    y =>
                        y.MapFrom(u => string.Empty))
                .ForMember(x => x.Status,
                    y =>
                        y.MapFrom(u => u.PostCommentStatus));
            CreateMap<PostCommentReplyFormViewModel, PostComment>();
            CreateMap<PostCommentStatus, PostCommentStatusEnumViewModel>();
            CreateMap<PostCommentStatusEnumViewModel, PostCommentStatus>();

            //Setting mappings
            CreateMap<Setting, SettingFormViewModel>();
            CreateMap<SettingFormViewModel, Setting>();

            //User mappings
            CreateMap<User, UserIndexViewModel>()
                .ForMember(x => x.UserFullName,
                    y =>
                        y.MapFrom<UserIndexViewModelUserFullNameResolver>());
            CreateMap<UserCreateFormViewModel, User>();
            CreateMap<User, UserFormViewModel>()
                .ForMember(x => x.FilePath,
                    y =>
                        y.MapFrom<UserFormViewModelFilePathResolver>()); ;
            CreateMap<UserFormViewModel, User>();
        }
    }
}
