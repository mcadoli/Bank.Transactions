$(document).ready(function (event) {
    event.preventDefault;
    RealizarUpload('fileupload', /(\.|\/)(csv|xls|xlsx)$/i, '/Home/UploadFiles', 3145728); 
});
function RealizarUpload(idInput, regex, url, maxTamArquivo) {
    $('#' + idInput + '').fileupload({
        dataType: 'json',
        url: url,
        acceptFileTypes: regex,
        maxFileSize: maxTamArquivo,
        autoUpload: true,
        done: function (e, data) {
            
        }
    })
}
       
