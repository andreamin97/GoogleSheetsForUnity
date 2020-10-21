# GoogleSheetsForUnity

## How to use

1. Enable Google Sheets API in the [Google Developers Dashboard](https://console.developers.google.com)
   1. Create a new project
   2. Create a new "Service User" with "service user" role
   3. Create a new JSON key for the account and download
2. Download the repo
3. Put the Plugins folder inside the Asset folder in your Unity Project
4. Add the GoogleSheetsForUnity script to a gameObject
5. Copy the Spreadsheet id and paste it in the relative field in the script
6. Copy the previously downloaded JSON file inside the Resources folder in the Unity Project
   1. rename it "credentials.json"
7. Open credentials.json and copy the client_email
8. In your spreadsheet, add the client email in the collaborators

And now you are done, whenever you need to do an operation on Google Sheets just the the script component and call the needed function.