<H1>Make a interactive video in unity using behaviour graphs!</H1>
To run this project just clone it and open in unity (version 6).
For building you can use the already created webgl build profile inside of unity which is tested to work on webGL, regular winapp should work fine too. 

---

**To add videos for use in graph:**
1. Add the desired video file to the StreamingAssets folder (the smaller the faster they will load online)
2. Go to the vide folder and right click and create a new scriptable object called "videoclip holder"
3. Give the videoclip holder a name and inside its videoclip value in the inspector set the name to the name of the videofile you added together wit its file ending (ex: hello.mp4)
4. Go into the main graph and add a new property of "videoclip holder" and assign it the newly created scriptable object you made
5. Now you can insert the video from the graph straight into the play video node!

---

**Nodes you can use in graph:**
* Play video (Plays a video), requires start time and end time => Wait for video finish.
* Set continue text (Shows a text button) => Wait for continue text.
* Set multichoice text, set up to 4 choice texts with each having own branching output
* Set quickaction with custom time.
  
