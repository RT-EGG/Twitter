# What is it?
<p>Collect the tweets contains image entity filtered by your keyword.</p>
<p>You can retweet, favorite and save image by each one button.</p>

# Remained problems...
I don't know I will really do it.
- [ ] Improve the handling of temporary memory for images.
- [ ] Remove overflowed tweet when collected too many tweets.
- [ ] Multi columns of searching tweet.
- [ ] Fix bugs.

# How to use.
1. At first run the application, you will be asked the application keys. Twitter API reqires key to develop applicaton. I want not to give my keys. So you must register twitter application development, and input the keys. The key information will be saved in directory at same location with exe file. It's not encrypted. You must not show it to others for your security.
2. Similar to the above, you will be asked pin code, and jump to authorize page on your default browser. Twitter application must be used by twitter account. So please authorize with your account to get pin code, and input that.
3. In the application, top text box is a keyword editor. Input your keyword and click "Change" button to search tweet by keyword. Then start the streaming of search tweet, will be updated column automatically.
4. Button at left or right are move tweet index. Buttons inside of the buttons are move image index case of the tweet has multi images.
5. A combo box at bottom left is to select directory that save images to. If a directory selected, text of the button is change to same to the directory. Click the button to save current shown image.
6. "RT","Fav" button are for do RT or favorite.