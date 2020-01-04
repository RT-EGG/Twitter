using CoreTweet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Imetter
{
    public delegate void UserProfileImagesReadyEvent(IUserProfileImages inImages);

    public interface IUserProfileImages
    {
        Image Icon { get; }
        Image Background { get; }
    }

    public class UserProfileImages : IUserProfileImages
    {
        public Image Icon
        { get; private set; } = null;
        public Image Background
        { get; private set; } = null;
        public DateTime LastUpdateTime
        { get; private set; } = DateTime.Now;

        private bool DefaultIconImage
        { get; set; } = false;
        private bool DefaultBackgroundImage
        { get; set; } = false;

        //public static void Query(User inUser, UserProfileImagesReadyEvent inOnReady)
        //{
        //    if (m_Images.TryGetValue(inUser.Name, out IUserProfileImages result)) {
        //        inOnReady?.Invoke(result);

        //    } else {
        //        NewImages(inUser, (IUserProfileImages inImage) => {
        //            m_Images.Add(inUser.Name, inImage);
        //            inOnReady(inImage);
        //        });
        //    }

        //    return;
        //}

        public static IUserProfileImages QueryAsync(User inUser, UserProfileImagesReadyEvent inOnReady)
        {
            if (m_Images.TryGetValue(inUser.Name, out IUserProfileImages result)) {
                return result;
            } else {

                UserProfileImages images = new UserProfileImages();
                images.DefaultIconImage = inUser.IsDefaultProfileImage;
                images.DefaultBackgroundImage = inUser.IsProfileUseBackgroundImage;

                if (!inUser.IsDefaultProfileImage) {
                    ImageDownloader.DownloadAsync(inUser.ProfileImageUrlHttps, (Bitmap inImage) => {
                        images.Icon = inImage;
                        if (images.DefaultBackgroundImage || (images.Background != null))
                            inOnReady?.Invoke(images);
                    });
                }
                if (!inUser.IsProfileUseBackgroundImage) {
                    ImageDownloader.DownloadAsync(inUser.ProfileBackgroundImageUrlHttps, (Bitmap inImage) => {
                        images.Background = inImage;
                        if (images.DefaultIconImage || (images.Icon != null))
                            inOnReady?.Invoke(images);
                    });
                }

                m_Images.Add(inUser.Name, images);
                return images;
            }
        }

        //private static void NewImages(User inUser, UserProfileImagesReadyEvent inOnReady)
        //{
        //    UserProfileImages images = new UserProfileImages();

        //    string[] urls = new string[new bool[]{ !inUser.IsDefaultProfileImage, !inUser.IsProfileUseBackgroundImage }.CountTrue()];
        //    int index = 0;

        //    if (!inUser.IsDefaultProfileImage)
        //        urls[index++] = inUser.ProfileImageUrlHttps;
        //    if (!inUser.IsProfileUseBackgroundImage)
        //        urls[index++] = inUser.ProfileBackgroundImageUrlHttps;

        //    if (urls.Length > 0) {
        //        ImageDownloader.Download(urls, (Bitmap[] inImages) => {
        //            index = 0;
        //            if (!inUser.IsDefaultProfileImage)
        //                images.Icon = inImages[index++];
        //            if (!inUser.IsProfileUseBackgroundImage)
        //                images.Background = inImages[index++];
        //            images.LastUpdateTime = DateTime.Now;
        //            inOnReady?.Invoke(images);
        //        });
        //    } else {
        //        images.LastUpdateTime = DateTime.Now;
        //        inOnReady?.Invoke(images);
        //    }
        //    return;
        //}

        private static Dictionary<string, IUserProfileImages> m_Images
        { get; } = new Dictionary<string, IUserProfileImages>();
    }
}
