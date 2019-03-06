using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace FormConfirmation
{
    public static class FormConfirmation
    {
        [FunctionName("FormConfirmation")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            dynamic data = await req.Content.ReadAsAsync<object>();
            var email = data?.email ?? String.Empty;

            if(!IsValidEmail(email.ToString() ?? String.Empty))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var emailRequest = new EmailRequest()
            {
                From = "Joe ATP, Complex Rehab Systems",
                FromEmail = "crs.support@kimobility.com",
                To = "Interested User",
                ToEmail = email,
                Subject = "Complex Rehab Systems - Thank you for signing up!",
                Html = EmailContent
            };

            var sendGridHelper = new SendGridHelper("RETRIEVE KEY FROM LASTPASS", "dpackard@kimobility.com", "Daniel Packard");
            sendGridHelper.Send(emailRequest);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // email compliant HTML generated with MJML: https://mjml.io/try-it-live/HJ0WeQiL4
        private const string EmailContent = @" 
<!doctype html>
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">

<head>
  <title> </title>
  <!--[if !mso]><!-- -->
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
  <!--<![endif]-->
  <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <style type=""text/css"">
    #outlook a {
      padding: 0;
    }

    .ReadMsgBody {
      width: 100%;
    }

    .ExternalClass {
      width: 100%;
    }

    .ExternalClass * {
      line-height: 100%;
    }

    body {
      margin: 0;
      padding: 0;
      -webkit-text-size-adjust: 100%;
      -ms-text-size-adjust: 100%;
    }

    table,
    td {
      border-collapse: collapse;
      mso-table-lspace: 0pt;
      mso-table-rspace: 0pt;
    }

    img {
      border: 0;
      height: auto;
      line-height: 100%;
      outline: none;
      text-decoration: none;
      -ms-interpolation-mode: bicubic;
    }

    p {
      display: block;
      margin: 13px 0;
    }
  </style>
  <!--[if !mso]><!-->
  <style type=""text/css"">
    @media only screen and (max-width:480px) {
      @-ms-viewport {
        width: 320px;
      }
      @viewport {
        width: 320px;
      }
    }
  </style>
  <!--<![endif]-->
  <!--[if mso]>
        <xml>
        <o:OfficeDocumentSettings>
          <o:AllowPNG/>
          <o:PixelsPerInch>96</o:PixelsPerInch>
        </o:OfficeDocumentSettings>
        </xml>
        <![endif]-->
  <!--[if lte mso 11]>
        <style type=""text/css"">
          .outlook-group-fix { width:100% !important; }
        </style>
        <![endif]-->
  <!--[if !mso]><!-->
  <link href=""https://fonts.googleapis.com/css?family=Roboto:300,400,500,700"" rel=""stylesheet"" type=""text/css"">
  <style type=""text/css"">
    @import url(https://fonts.googleapis.com/css?family=Roboto:300,400,500,700);
  </style>
  <!--<![endif]-->
  <style type=""text/css"">
    @media only screen and (min-width:480px) {
      .mj-column-per-100 {
        width: 100% !important;
        max-width: 100%;
      }
    }
  </style>
  <style type=""text/css"">
    @media only screen and (max-width:480px) {
      table.full-width-mobile {
        width: 100% !important;
      }
      td.full-width-mobile {
        width: auto !important;
      }
    }
  </style>
</head>

<body>
  <div style="""">
    <!--[if mso | IE]>
      <table
         align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""" style=""width:600px;"" width=""600""
      >
        <tr>
          <td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;"">
      <![endif]-->
    <div style=""Margin:0px auto;max-width:600px;"">
      <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;"">
        <tbody>
          <tr>
            <td style=""direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;"">
              <!--[if mso | IE]>
                  <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                
        <tr>
      
            <td
               class="""" style=""vertical-align:top;width:600px;""
            >
          <![endif]-->
              <div class=""mj-column-per-100 outlook-group-fix"" style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""vertical-align:top;"" width=""100%"">
                  <tr>
                    <td align=""left"" style=""font-size:0px;padding:10px 25px;word-break:break-word;"">
                      <div style=""font-family:roboto;font-size:20px;line-height:1;text-align:left;color:#555555;""> Thank you for contacting us! </div>
                    </td>
                  </tr>
                  <tr>
                    <td align=""left"" style=""font-size:0px;padding:10px 25px;word-break:break-word;"">
                      <div style=""font-family:roboto;font-size:20px;line-height:1;text-align:left;color:#555555;""> You have been added to the email list to receive updates. </div>
                    </td>
                  </tr>
                  <tr>
                    <td style=""font-size:0px;padding:10px 25px;word-break:break-word;"">
                      <p style=""border-top:solid 4px #148FCE;font-size:1;margin:0px auto;width:100%;""> </p>
                      <!--[if mso | IE]>
        <table
           align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-top:solid 4px #148FCE;font-size:1;margin:0px auto;width:550px;"" role=""presentation"" width=""550px""
        >
          <tr>
            <td style=""height:0;line-height:0;"">
              &nbsp;
            </td>
          </tr>
        </table>
      <![endif]-->
                    </td>
                  </tr>
                  <tr>
                    <td align=""center"" style=""font-size:0px;padding:10px 25px;word-break:break-word;"">
                      <table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""border-collapse:collapse;border-spacing:0px;"">
                        <tbody>
                          <tr>
                            <td style=""width:300px;""> <img height=""auto"" src=""https://complexrehabsystems.com/static/Joe-ATP-LeftWave.7d7c382c.png"" style=""border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;"" width=""300"" /> </td>
                          </tr>
                        </tbody>
                      </table>
                    </td>
                  </tr>
                </table>
              </div>
              <!--[if mso | IE]>
            </td>
          
        </tr>
      
                  </table>
                <![endif]-->
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <!--[if mso | IE]>
          </td>
        </tr>
      </table>
      <![endif]-->
  </div>
</body>

</html>
";

    }
}
