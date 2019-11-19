This is small program which allows you to easily modify XML files from mod University Costs More created by Zero. Instead of tedious clicking and editing files in Sims4Studio you can create a CSV and modify all files at once. Though you need to go through some easy steps.

1. Create CSV file.
  You need a formatted file which contains all required values. To do it just download and open CSVtoEdit.csv file. There you can see deafult cost for each class in the Sims 4 university. Feel free to modify values as you want, but keep in mind this values have to be INTEGERS!!! as Sims 4 money can't be decimals. Also don't setup values to high, I didn't check the limit, though values around 1000000 per class shoulddn't be a problem.
  
  PS: Don't change first column (that with ABCD) and top row (with degree names).
 
2. Using Sims4Studio open Zero_UniversityCostsMore_MainClasses.package. Sort by column with university_CourseData_somethin (just click on top of that column). Select all files with description in that column.
![alt text](https://i.imgur.com/4aj0n3T.png)
Click BATCH EXPORT and select preferably empty folder. You should get exactly 156 files (13 degrees * 12 classes).

3. Open my program using Sims4TuitionXMLGenerator.exe. Close .CSV file you modified and all .XML files you just exported. Click button Search CSV (1 on the image) and pick your modified .CSV file. Then click Search XML button (2 on the image) and pick directory containing exported .XML files. Click Replace Button (3 on the image), wait for messege box and close the program.

![alt text](https://i.imgur.com/a9tgcP4.png)

4. Back to Sims4Studio. Again sort by column with university_CourseData_somethin and select all files with description in that column. This time click BATCH IMPORT and select all .XML files you just exported and modified (files will look like on the image below).

![alt text](https://i.imgur.com/A15DqM3.png)

5. Voila. All values should be changed and you can play the game.


PS: I didn't make this program idiot-proof (no offence) so it's quite easy to do something wrong. Though using it is also not so complicated thing in the world. Just a bit of selecting files and searching in directory tree.
