function getData(id, sheetName) {
  var sheet = SpreadsheetApp.openById(id).getSheetByName(sheetName);
  var rows = sheet.getDataRange().getValues();
  var keys = rows.splice(0, 1)[0];
  return rows.map(function(row) {
    var obj = {}
    row.map(function(item, index) {
      obj[keys[index]] = item;
    });
    return obj;
  });
}
function doGet(e) {
  var id = e.parameter.sheetId;
  var data = getData(id, e.parameter.sheetName);
  return ContentService.createTextOutput(JSON.stringify(data, null, 2))
  .setMimeType(ContentService.MimeType.JSON);
}
