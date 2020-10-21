using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class GoogleSheetsForUnity : MonoBehaviour
{ 
    static string[] Scopes = { SheetsService.Scope.Spreadsheets };
    static string ApplicationName = "Google Sheets for Unity";
    public String spreadsheetId = "1YNeuMS9ERTmX9XBTKtZ_KExDyFcBGUqZWuIozr68oWw";

    private SheetsService service;
    
    // Start is called before the first frame update
    void Start()
    {
        GoogleCredential credential;
        
        /*using (var stream =
            new FileStream("Assets/credentials.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream)
                .CreateScoped((Scopes));
        }*/

        var credentialsTextAsset = Resources.Load<TextAsset>("credentials");
        credential = GoogleCredential.FromJson(credentialsTextAsset.text.ToString())
            .CreateScoped((Scopes));

        // Create Google Sheets API service.
        service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
       
       StartCoroutine(AppendToSheet("Sheet1", "A:F", new List<object>(){"=row()", "=row()*16", "=row()*13", "=row()*19", "=row()*7"}));
    }

    public IEnumerator AppendToSheet(string sheet, string range, List<object> values)
    {
        string compositeRange = $"{sheet}!{range}";
        
        ValueRange valueRange = new ValueRange();
        valueRange.Values = new List<IList<object>> {values};
        
        SpreadsheetsResource.ValuesResource.AppendRequest request =
            service.Spreadsheets.Values.Append(valueRange, spreadsheetId, compositeRange);
        request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        request.Execute();
        
        yield return null;
    }
}
