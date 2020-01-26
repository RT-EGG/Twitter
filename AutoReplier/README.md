# First...
This is incomplete program. You must complete by your information and needs.

# What is it?
Send tweet automatically by some tweets as a signal.<br>
Especially, when specific user tweet specific word, the fixed tweet will be sent.<br>
(It will receive error for twice same tweet...).

# What complement is needed to use?
1. Head of class FormMain. "TargetUserID" is monitored user screen name.
2. Check the variable "targetIsLockedAccount" at FormMain.AuthorizeUser(). If the monitored account is locked, change this value to true.
3. To change behavior when receive tweet, edit FormMain.CheckTweetForReaction(). Argument "inStatus" is a received tweet.
4. At first run the application, you will be asked the application keys. Twitter API reqires key to develop applicaton. I want not to give my keys. So you must register twitter application development, and input the keys. The key information will be saved in directory at same location with exe file. It's not encrypted. You must not show it to others for your security.
5. Similar to the above, you will be asked pin code, and jump to authorize page on your default browser. Twitter application must be used by twitter account. So please authorize with your account to get pin code, and input that.
6. You can use this application. should be, should be...