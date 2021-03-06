using System;
using Fiddler;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace Fiddler
{
    public static class Handlers 
    {

        [RulesOption("Hide 304s")]
        [BindPref("fiddlerscript.rules.Hide304s")]
        public static bool m_Hide304s = false;

        [RulesOption("Request &Japanese Content")]
        public static bool m_Japanese = false;

        [RulesOption("&Automatically Authenticate")]
        [BindPref("fiddlerscript.rules.AutoAuth")]
        public static bool m_AutoAuth = false;

        [RulesString("&User-Agents", true)] 
        [BindPref("fiddlerscript.ephemeral.UserAgentString")]
        [RulesStringValue(0, "Netscape &3", "Mozilla/3.0 (Win95; I)")]
        [RulesStringValue(1, "WinPhone8.1", "Mozilla/5.0 (Mobile; Windows Phone 8.1; Android 4.0; ARM; Trident/7.0; Touch; rv:11.0; IEMobile/11.0; NOKIA; Lumia 520) like iPhone OS 7_0_3 Mac OS X AppleWebKit/537 (KHTML, like Gecko) Mobile Safari/537")]
        [RulesStringValue(2, "&Safari5 (Win7)", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.21.1 (KHTML, like Gecko) Version/5.0.5 Safari/533.21.1")]
        [RulesStringValue(3, "Safari9 (Mac)", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11) AppleWebKit/601.1.56 (KHTML, like Gecko) Version/9.0 Safari/601.1.56")]
        [RulesStringValue(4, "iPad", "Mozilla/5.0 (iPad; CPU OS 8_3 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Version/8.0 Mobile/12F5027d Safari/600.1.4")]
        [RulesStringValue(5, "iPhone6", "Mozilla/5.0 (iPhone; CPU iPhone OS 8_3 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Version/8.0 Mobile/12F70 Safari/600.1.4")]
        [RulesStringValue(6, "IE &6 (XPSP2)", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)")]
        [RulesStringValue(7, "IE &7 (Vista)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1)")]
        [RulesStringValue(8, "IE 8 (Win2k3 x64)", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.2; WOW64; Trident/4.0)")]
        [RulesStringValue(9, "IE &8 (Win7)", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)")]
        [RulesStringValue(10, "IE 9 (Win7)", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)")]
        [RulesStringValue(11, "IE 10 (Win8)", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)")]
        [RulesStringValue(12, "IE 11 (Surface2)", "Mozilla/5.0 (Windows NT 6.3; ARM; Trident/7.0; Touch; rv:11.0) like Gecko")]
        [RulesStringValue(13, "IE 11 (Win8.1)", "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko")]
        [RulesStringValue(14, "Edge (Win10)", "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36 Edge/13.11082")]
        [RulesStringValue(15, "&Opera", "Opera/9.80 (Windows NT 6.2; WOW64) Presto/2.12.388 Version/12.17")]
        [RulesStringValue(16, "&Firefox 3.6", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.7) Gecko/20100625 Firefox/3.6.7")]
        [RulesStringValue(17, "&Firefox 43", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:43.0) Gecko/20100101 Firefox/43.0")]
        [RulesStringValue(18, "&Firefox Phone", "Mozilla/5.0 (Mobile; rv:18.0) Gecko/18.0 Firefox/18.0")]
        [RulesStringValue(19, "&Firefox (Mac)", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.8; rv:24.0) Gecko/20100101 Firefox/24.0")]
        [RulesStringValue(20, "Chrome (Win)", "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.48 Safari/537.36")]
        [RulesStringValue(21, "Chrome (Android)", "Mozilla/5.0 (Linux; Android 5.1.1; Nexus 5 Build/LMY48B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.78 Mobile Safari/537.36")]
        [RulesStringValue(22, "ChromeBook", "Mozilla/5.0 (X11; CrOS x86_64 6680.52.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.74 Safari/537.36")]
        [RulesStringValue(23, "GoogleBot Crawler", "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)")]
        [RulesStringValue(24, "Kindle Fire (Silk)", "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_3; en-us; Silk/1.0.22.79_10013310) AppleWebKit/533.16 (KHTML, like Gecko) Version/5.0 Safari/533.16 Silk-Accelerated=true")]
        [RulesStringValue(25, "&Custom...", "%CUSTOM%")]
        public static string sUA = null;

        [RulesOption("Simulate &Modem Speeds", "Per&formance")]
        public static bool m_SimulateModem = false;

        [RulesOption("&Disable Caching", "Per&formance")]
        public static bool m_DisableCaching = false;

        [RulesOption("Cache Always &Fresh", "Per&formance")]
        public static bool m_AlwaysFresh = false;

        [ToolsAction("Reset Script")]
        public static void DoManualReload()
        {
            FiddlerObject.ReloadScript();
        }

        [ContextAction("Decode Selected Sessions")]
        public static void DoRemoveEncoding(Session[] arrSessions) 
        {
            for (int x = 0; x < arrSessions.Length; x++)
            {
                arrSessions[x].utilDecodeRequest();
                arrSessions[x].utilDecodeResponse();
            }

            FiddlerApplication.UI.actUpdateInspector(true,true);
        }

        public static void OnBeforeRequest(Session oSession) 
        {

            if ((null != gs_ReplaceToken) && (oSession.url.IndexOf(gs_ReplaceToken)>-1))     // Case sensitive
            {
                oSession.url = oSession.url.Replace(gs_ReplaceToken, gs_ReplaceTokenWith); 
            }

            if ((null != gs_OverridenHost) && (oSession.host.ToLower() == gs_OverridenHost))
            {
                oSession["x-overridehost"] = gs_OverrideHostWith; 
            }

            if ((null!=bpRequestURI) && oSession.uriContains(bpRequestURI))
            {
                oSession["x-breakrequest"]="uri";
            }

            if ((null!=bpMethod) && (oSession.HTTPMethodIs(bpMethod)))
            {
                oSession["x-breakrequest"]="method";
            }

            if ((null!=uiBoldURI) && oSession.uriContains(uiBoldURI))
            {
                oSession["ui-bold"]="QuickExec";
            }

            if (m_SimulateModem)
            {
                oSession["request-trickle-delay"] = "300"; 
                oSession["response-trickle-delay"] = "150"; 
            }

            if (m_DisableCaching)
            {
                oSession.oRequest.headers.Remove("If-None-Match");
                oSession.oRequest.headers.Remove("If-Modified-Since");
                oSession.oRequest["Pragma"] = "no-cache";
            }

            if (null != sUA)
            {
                oSession.oRequest["User-Agent"] = sUA; 
            }

            if (m_Japanese)
            {
                oSession.oRequest["Accept-Language"] = "ja";
            }

            if (m_AutoAuth)
            {
                oSession["X-AutoAuth"] = "(default)";
            }

            if (m_AlwaysFresh && (oSession.oRequest.headers.Exists("If-Modified-Since") || oSession.oRequest.headers.Exists("If-None-Match")))
            {
                oSession.utilCreateResponseAndBypassServer();
                oSession.responseCode = 304;
                oSession["ui-backcolor"] = "Lavender";
            }
        }

        /*
        public static void OnPeekAtRequestHeaders(Session oSession) 
        {
            string sProc = oSession["x-ProcessInfo"].ToLower();
            if (!sProc.StartsWith("mylowercaseappname")) oSession["ui-hide"] = "NotMyApp";
        }
        */

        public static void OnPeekAtResponseHeaders(Session oSession) 
        {
            
            if (m_DisableCaching)
            {
                oSession.oResponse.headers.Remove("Expires");
                oSession.oResponse["Cache-Control"] = "no-cache";
            }

            if ((bpStatus>0) && (oSession.responseCode == bpStatus))
            {
                oSession["x-breakresponse"]="status";
                oSession.bBufferResponse = true;
            }

            if ((null!=bpResponseURI) && oSession.uriContains(bpResponseURI))
            {
                oSession["x-breakresponse"]="uri";
                oSession.bBufferResponse = true;
            }
        }

        public static void OnBeforeResponse(Session oSession)
        {
            if (m_Hide304s && oSession.responseCode == 304)
            {
                oSession["ui-hide"] = "true";
            }
        }

        public static void Main() 
        {
            string today = DateTime.Now.ToShortTimeString();
            FiddlerApplication.UI.SetStatusText(" CustomRules.cs was loaded at: " + today);

            // FiddlerApplication.UI.lvSessions.AddBoundColumn("Server", 50, "@response.server");
            // FiddlerApplication.UI.RegisterCustomHotkey(HotkeyModifiers.Windows, Keys.G, "screenshot"); 
        }

        [BindPref("fiddlerscript.ephemeral.bpRequestURI")]
        public static string bpRequestURI = null;

        [BindPref("fiddlerscript.ephemeral.bpResponseURI")]
        public static string bpResponseURI = null;

        [BindPref("fiddlerscript.ephemeral.bpMethod")]
        public static string bpMethod = null;

        static int bpStatus = -1;
        static string uiBoldURI = null;
        static string gs_ReplaceToken = null;
        static string gs_ReplaceTokenWith = null;
        static string gs_OverridenHost = null;
        static string gs_OverrideHostWith = null;

        public static bool OnExecAction(string[] sParams)
        {
            FiddlerApplication.UI.SetStatusText("ExecAction: " + sParams[0]);
            string sAction = sParams[0].ToLower();
            switch (sAction) 
            {
            case "bold":
                if (sParams.Length<2) {uiBoldURI=null; FiddlerApplication.UI.SetStatusText("Bolding cleared"); return false;}
                uiBoldURI = sParams[1]; FiddlerApplication.UI.SetStatusText("Bolding requests for " + uiBoldURI);
                return true;
            case "bp":
                MessageBox.Show("bpu = breakpoint request for uri\nbpm = breakpoint request method\nbps=breakpoint response status\nbpafter = breakpoint response for URI");
                return true;
            case "bps":
                if (sParams.Length<2) {bpStatus=-1; FiddlerApplication.UI.SetStatusText("Response Status breakpoint cleared"); return false;}
                bpStatus = Int32.Parse(sParams[1]); FiddlerApplication.UI.SetStatusText("Response status breakpoint for " + sParams[1]);
                return true;
            case "bpv":
            case "bpm":
                if (sParams.Length<2) {bpMethod=null; FiddlerApplication.UI.SetStatusText("Request Method breakpoint cleared"); return false;}
                bpMethod = sParams[1].ToUpper(); FiddlerApplication.UI.SetStatusText("Request Method breakpoint for " + bpMethod);
                return true;
            case "bpu":
                if (sParams.Length<2) {bpRequestURI=null; FiddlerApplication.UI.SetStatusText("RequestURI breakpoint cleared"); return false;}
                bpRequestURI = sParams[1]; 
                FiddlerApplication.UI.SetStatusText("RequestURI breakpoint for "+sParams[1]);
                return true;
            case "bpa":
            case "bpafter":
                if (sParams.Length<2) {bpResponseURI=null; FiddlerApplication.UI.SetStatusText("ResponseURI breakpoint cleared"); return false;}
                bpResponseURI = sParams[1]; 
                FiddlerApplication.UI.SetStatusText("ResponseURI breakpoint for "+sParams[1]);
                return true;
            case "overridehost":
                if (sParams.Length<3) {gs_OverridenHost=null; FiddlerApplication.UI.SetStatusText("Host Override cleared"); return false;}
                gs_OverridenHost = sParams[1].ToLower();
                gs_OverrideHostWith = sParams[2];
                FiddlerApplication.UI.SetStatusText("Connecting to [" + gs_OverrideHostWith + "] for requests to [" + gs_OverridenHost + "]");
                return true;
            case "urlreplace":
                if (sParams.Length<3) {gs_ReplaceToken=null; FiddlerApplication.UI.SetStatusText("URL Replacement cleared"); return false;}
                gs_ReplaceToken = sParams[1];
                gs_ReplaceTokenWith = sParams[2].Replace(" ", "%20");  // Simple helper
                FiddlerApplication.UI.SetStatusText("Replacing [" + gs_ReplaceToken + "] in URIs with [" + gs_ReplaceTokenWith + "]");
                return true;
            case "allbut":
            case "keeponly":
                if (sParams.Length<2) { FiddlerApplication.UI.SetStatusText("Please specify Content-Type to retain during wipe."); return false;}
                FiddlerApplication.UI.actSelectSessionsWithResponseHeaderValue("Content-Type", sParams[1]);
                FiddlerApplication.UI.actRemoveUnselectedSessions();
                FiddlerApplication.UI.lvSessions.SelectedItems.Clear();
                FiddlerApplication.UI.SetStatusText("Removed all but Content-Type: " + sParams[1]);
                return true;
            case "stop":
                FiddlerApplication.UI.actDetachProxy();
                return true;
            case "start":
                FiddlerApplication.UI.actAttachProxy();
                return true;
            case "cls":
            case "clear":
                FiddlerApplication.UI.actRemoveAllSessions();
                return true;
            case "g":
            case "go":
                FiddlerApplication.UI.actResumeAllSessions();
                return true;
            case "goto":
                if (sParams.Length != 2) return false;
                Utilities.LaunchHyperlink("http://www.google.com/search?hl=en&btnI=I%27m+Feeling+Lucky&q=" + Utilities.UrlEncode(sParams[1]));
                return true;
            case "help":
                Utilities.LaunchHyperlink("http://fiddler2.com/r/?quickexec");
                return true;
            case "hide":
                FiddlerApplication.UI.actMinimizeToTray();
                return true;
            case "log":
                FiddlerApplication.Log.LogString((sParams.Length<2) ? "User couldn't think of anything to say..." : sParams[1]);
                return true;
            case "nuke":
                FiddlerApplication.UI.actClearWinINETCache();
                FiddlerApplication.UI.actClearWinINETCookies(); 
                return true;
            case "screenshot":
                FiddlerApplication.UI.actCaptureScreenshot(false);
                return true;
            case "show":
                FiddlerApplication.UI.actRestoreWindow();
                return true;
            case "tail":
                if (sParams.Length<2) { FiddlerApplication.UI.SetStatusText("Please specify # of sessions to trim the session list to."); return false;}
                FiddlerApplication.UI.TrimSessionList(int.Parse(sParams[1]));
                return true;
            case "quit":
                FiddlerApplication.UI.actExit();
                return true;
            case "dump":
                FiddlerApplication.UI.actSelectAll();
                FiddlerApplication.UI.actSaveSessionsToZip(CONFIG.GetPath("Captures") + "dump.saz");
                FiddlerApplication.UI.actRemoveAllSessions();
                FiddlerApplication.UI.SetStatusText("Dumped all sessions to " + CONFIG.GetPath("Captures") + "dump.saz");
                return true;

            default:
                if (sAction.StartsWith("http") || sAction.StartsWith("www"))
                {
                    System.Diagnostics.Process.Start(sParams[0]);
                    return true;
                }
                else
                {
                    FiddlerApplication.UI.SetStatusText("Requested ExecAction: '" + sAction + "' not found. Type HELP to learn more.");
                    return false;
                }
            }
        }
    }
}
