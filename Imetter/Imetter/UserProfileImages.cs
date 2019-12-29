using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoreTweet;

namespace TwitterTimeLine
{
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

        public static IUserProfileImages Query(User inUser)
        {
            IUserProfileImages result;
            if (!m_Images.TryGetValue(inUser.Name, out result)) {
                result = NewImages(inUser);
                m_Images.Add(inUser.Name, result);
            }

            return result;
        }

        public static async Task<IUserProfileImages> QueryAsync(User inUser)
        {
            IUserProfileImages result;
            if (!m_Images.TryGetValue(inUser.Name, out result)) {
                result = await NewImageAsync(inUser);
                m_Images.Add(inUser.Name, result);
            }

            return result;
        }

        private static IUserProfileImages NewImages(User inUser)
        {
            UserProfileImages images = new UserProfileImages();
            if (!inUser.IsDefaultProfileImage)
                images.Icon = ImageDownloader.Download(inUser.ProfileImageUrlHttps);
            if (!inUser.IsProfileUseBackgroundImage)
                images.Background = ImageDownloader.Download(inUser.ProfileBackgroundImageUrlHttps);

            images.LastUpdateTime = DateTime.Now;
            return images;
        }

        private static async Task<IUserProfileImages> NewImageAsync(User inUser)
        {
            UserProfileImages images = new UserProfileImages();
            if (!inUser.IsDefaultProfileImage)
                images.Icon = await ImageDownloader.DownloadAsync(inUser.ProfileImageUrlHttps);
            if (!inUser.IsProfileUseBackgroundImage)
                images.Background = await ImageDownloader.DownloadAsync(inUser.ProfileBackgroundImageUrlHttps);

            images.LastUpdateTime = DateTime.Now;
            return images;
        }

        private static Dictionary<string, IUserProfileImages> m_Images
        { get; } = new Dictionary<string, IUserProfileImages>();
    }
}
