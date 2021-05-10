using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Mappings.Resolvers.WebsiteFrontResolvers;
using AMZEnterpriseWebsite.Models.ViewModels;
using AutoMapper;

namespace AMZEnterpriseWebsite.Mappings
{
    public class WebsiteFrontProfile : Profile
    {
        public WebsiteFrontProfile()
        {
            //Footer mapping
            CreateMap<Setting, FooterViewModel>();

            //Contact mapping
            CreateMap<Setting, ContactViewModel>();

            //Donate mapping
            CreateMap<Setting, DonateViewModel>();

            //Blog mappings
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<Post, PostViewModel>()
                .ForMember(x => x.PostCategoryViewModel,
                    y =>
                        y.MapFrom(u => u.PostCategory))
                .ForMember(x => x.UserFullName,
                    y =>
                        y.MapFrom<PostViewModelUserFullNameResolver>())
                .ForMember(x => x.UserFilePath,
                    y =>
                        y.MapFrom<PostViewModelUserFilePathResolver>())
                .ForMember(x => x.FilePath,
                    y => y.MapFrom<PostViewModelFilePathResolver>())
                .ForMember(x => x.PostCommentViewModels,
                    y =>
                        y.MapFrom(u => u.PostComments));
            CreateMap<PostComment, PostCommentViewModel>()
                .ForMember(x => x.UserFullName,
                    y =>
                        y.MapFrom<PostCommentViewModelUserFullName>());
            CreateMap<PostCommentFormViewModel, PostComment>();

            //Contact mapping
            CreateMap<ContactFormViewModel, Contact>();

            //Certificate mapping
            CreateMap<Certificate, CertificateViewModel>()
                .ForMember(x => x.FilePath,
                    y =>
                        y.MapFrom<CertificateViewModelFilePathResolver>());
        }
    }
}
