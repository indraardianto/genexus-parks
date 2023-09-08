using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx0070 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0070( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0070( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pRepairId )
      {
         this.AV13pRepairId = 0 ;
         executePrivate();
         aP0_pRepairId=this.AV13pRepairId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pRepairId");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pRepairId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pRepairId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."));
               sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
               AV6cRepairId = (short)(NumberUtil.Val( GetPar( "cRepairId"), "."));
               AV7cRepairDateFrom = context.localUtil.ParseDateParm( GetPar( "cRepairDateFrom"));
               AV8cRepairDaysQuantity = (short)(NumberUtil.Val( GetPar( "cRepairDaysQuantity"), "."));
               AV9cGameId = (short)(NumberUtil.Val( GetPar( "cGameId"), "."));
               AV10cRepairCost = (short)(NumberUtil.Val( GetPar( "cRepairCost"), "."));
               AV11cTechnicianId = (short)(NumberUtil.Val( GetPar( "cTechnicianId"), "."));
               AV12cRepairAlternateTechnicianId = (short)(NumberUtil.Val( GetPar( "cRepairAlternateTechnicianId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cRepairId, AV7cRepairDateFrom, AV8cRepairDaysQuantity, AV9cGameId, AV10cRepairCost, AV11cTechnicianId, AV12cRepairAlternateTechnicianId) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "REPAIRIDFILTERCONTAINER_Class", StringUtil.RTrim( divRepairidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "REPAIRDATEFROMFILTERCONTAINER_Class", StringUtil.RTrim( divRepairdatefromfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "REPAIRDAYSQUANTITYFILTERCONTAINER_Class", StringUtil.RTrim( divRepairdaysquantityfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "GAMEIDFILTERCONTAINER_Class", StringUtil.RTrim( divGameidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "REPAIRCOSTFILTERCONTAINER_Class", StringUtil.RTrim( divRepaircostfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TECHNICIANIDFILTERCONTAINER_Class", StringUtil.RTrim( divTechnicianidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "REPAIRALTERNATETECHNICIANIDFILTERCONTAINER_Class", StringUtil.RTrim( divRepairalternatetechnicianidfiltercontainer_Class));
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pRepairId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pRepairId", StringUtil.LTrimStr( (decimal)(AV13pRepairId), 4, 0));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Q2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 182860), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202361614433716", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0070.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pRepairId,4,0))}, new string[] {"pRepairId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCREPAIRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cRepairId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCREPAIRDATEFROM", context.localUtil.Format(AV7cRepairDateFrom, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCREPAIRDAYSQUANTITY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cRepairDaysQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCGAMEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cGameId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCREPAIRCOST", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cRepairCost), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTECHNICIANID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cTechnicianId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCREPAIRALTERNATETECHNICIANID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cRepairAlternateTechnicianId), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPREPAIRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pRepairId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "REPAIRIDFILTERCONTAINER_Class", StringUtil.RTrim( divRepairidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REPAIRDATEFROMFILTERCONTAINER_Class", StringUtil.RTrim( divRepairdatefromfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REPAIRDAYSQUANTITYFILTERCONTAINER_Class", StringUtil.RTrim( divRepairdaysquantityfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "GAMEIDFILTERCONTAINER_Class", StringUtil.RTrim( divGameidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REPAIRCOSTFILTERCONTAINER_Class", StringUtil.RTrim( divRepaircostfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TECHNICIANIDFILTERCONTAINER_Class", StringUtil.RTrim( divTechnicianidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REPAIRALTERNATETECHNICIANIDFILTERCONTAINER_Class", StringUtil.RTrim( divRepairalternatetechnicianidfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Q2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx0070.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pRepairId,4,0))}, new string[] {"pRepairId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0070" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Repair" ;
      }

      protected void WB0Q0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepairidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRepairidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrepairidfilter_Internalname, "Repair Id", "", "", lblLblrepairidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110q1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrepairid_Internalname, "Repair Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrepairid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cRepairId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCrepairid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cRepairId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cRepairId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrepairid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrepairid_Visible, edtavCrepairid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepairdatefromfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRepairdatefromfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrepairdatefromfilter_Internalname, "Repair Date From", "", "", lblLblrepairdatefromfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120q1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrepairdatefrom_Internalname, "Repair Date From", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCrepairdatefrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCrepairdatefrom_Internalname, context.localUtil.Format(AV7cRepairDateFrom, "99/99/99"), context.localUtil.Format( AV7cRepairDateFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrepairdatefrom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCrepairdatefrom_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepairdaysquantityfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRepairdaysquantityfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrepairdaysquantityfilter_Internalname, "Repair Days Quantity", "", "", lblLblrepairdaysquantityfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130q1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrepairdaysquantity_Internalname, "Repair Days Quantity", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrepairdaysquantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cRepairDaysQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCrepairdaysquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cRepairDaysQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cRepairDaysQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrepairdaysquantity_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrepairdaysquantity_Visible, edtavCrepairdaysquantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGameidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divGameidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblgameidfilter_Internalname, "Game Id", "", "", lblLblgameidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140q1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCgameid_Internalname, "Game Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCgameid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cGameId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCgameid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cGameId), "ZZZ9") : context.localUtil.Format( (decimal)(AV9cGameId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCgameid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCgameid_Visible, edtavCgameid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepaircostfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRepaircostfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrepaircostfilter_Internalname, "Repair Cost", "", "", lblLblrepaircostfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150q1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrepaircost_Internalname, "Repair Cost", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrepaircost_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cRepairCost), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCrepaircost_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cRepairCost), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cRepairCost), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrepaircost_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrepaircost_Visible, edtavCrepaircost_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTechnicianidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTechnicianidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltechnicianidfilter_Internalname, "Technician Id", "", "", lblLbltechnicianidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160q1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtechnicianid_Internalname, "Technician Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtechnicianid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cTechnicianId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCtechnicianid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cTechnicianId), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cTechnicianId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtechnicianid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtechnicianid_Visible, edtavCtechnicianid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRepairalternatetechnicianidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRepairalternatetechnicianidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrepairalternatetechnicianidfilter_Internalname, "Repair Alternate Technician Id", "", "", lblLblrepairalternatetechnicianidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170q1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrepairalternatetechnicianid_Internalname, "Repair Alternate Technician Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrepairalternatetechnicianid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cRepairAlternateTechnicianId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCrepairalternatetechnicianid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cRepairAlternateTechnicianId), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cRepairAlternateTechnicianId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrepairalternatetechnicianid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrepairalternatetechnicianid_Visible, edtavCrepairalternatetechnicianid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180q1_client"+"'", TempTags, "", 2, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Date From") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Days Quantity") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Game Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Cost") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Technician Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Technician Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22RepairId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A23RepairDateFrom, "99/99/99"));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtRepairDateFrom_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RepairDaysQuantity), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16GameId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26RepairCost), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27TechnicianId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29RepairAlternateTechnicianId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Q2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "Selection List Repair", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0Q0( ) ;
      }

      protected void WS0Q2( )
      {
         START0Q2( ) ;
         EVT0Q2( ) ;
      }

      protected void EVT0Q2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A22RepairId = (short)(context.localUtil.CToN( cgiGet( edtRepairId_Internalname), ".", ","));
                              A23RepairDateFrom = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtRepairDateFrom_Internalname), 0));
                              A24RepairDaysQuantity = (short)(context.localUtil.CToN( cgiGet( edtRepairDaysQuantity_Internalname), ".", ","));
                              A16GameId = (short)(context.localUtil.CToN( cgiGet( edtGameId_Internalname), ".", ","));
                              A26RepairCost = (short)(context.localUtil.CToN( cgiGet( edtRepairCost_Internalname), ".", ","));
                              A27TechnicianId = (short)(context.localUtil.CToN( cgiGet( edtTechnicianId_Internalname), ".", ","));
                              A29RepairAlternateTechnicianId = (short)(context.localUtil.CToN( cgiGet( edtRepairAlternateTechnicianId_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Crepairid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREPAIRID"), ".", ",") != Convert.ToDecimal( AV6cRepairId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crepairdatefrom Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCREPAIRDATEFROM"), 0) != AV7cRepairDateFrom )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crepairdaysquantity Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREPAIRDAYSQUANTITY"), ".", ",") != Convert.ToDecimal( AV8cRepairDaysQuantity )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cgameid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCGAMEID"), ".", ",") != Convert.ToDecimal( AV9cGameId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crepaircost Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREPAIRCOST"), ".", ",") != Convert.ToDecimal( AV10cRepairCost )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctechnicianid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTECHNICIANID"), ".", ",") != Convert.ToDecimal( AV11cTechnicianId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crepairalternatetechnicianid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREPAIRALTERNATETECHNICIANID"), ".", ",") != Convert.ToDecimal( AV12cRepairAlternateTechnicianId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210Q2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0Q2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cRepairId ,
                                        DateTime AV7cRepairDateFrom ,
                                        short AV8cRepairDaysQuantity ,
                                        short AV9cGameId ,
                                        short AV10cRepairCost ,
                                        short AV11cTechnicianId ,
                                        short AV12cRepairAlternateTechnicianId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_REPAIRID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A22RepairId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "REPAIRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22RepairId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cRepairDateFrom ,
                                                 AV8cRepairDaysQuantity ,
                                                 AV9cGameId ,
                                                 AV10cRepairCost ,
                                                 AV11cTechnicianId ,
                                                 AV12cRepairAlternateTechnicianId ,
                                                 A23RepairDateFrom ,
                                                 A24RepairDaysQuantity ,
                                                 A16GameId ,
                                                 A26RepairCost ,
                                                 A27TechnicianId ,
                                                 A29RepairAlternateTechnicianId ,
                                                 AV6cRepairId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H000Q2 */
            pr_default.execute(0, new Object[] {AV6cRepairId, AV7cRepairDateFrom, AV8cRepairDaysQuantity, AV9cGameId, AV10cRepairCost, AV11cTechnicianId, AV12cRepairAlternateTechnicianId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A29RepairAlternateTechnicianId = H000Q2_A29RepairAlternateTechnicianId[0];
               A27TechnicianId = H000Q2_A27TechnicianId[0];
               A26RepairCost = H000Q2_A26RepairCost[0];
               A16GameId = H000Q2_A16GameId[0];
               A24RepairDaysQuantity = H000Q2_A24RepairDaysQuantity[0];
               A23RepairDateFrom = H000Q2_A23RepairDateFrom[0];
               A22RepairId = H000Q2_A22RepairId[0];
               /* Execute user event: Load */
               E200Q2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0Q0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Q2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_REPAIRID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A22RepairId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cRepairDateFrom ,
                                              AV8cRepairDaysQuantity ,
                                              AV9cGameId ,
                                              AV10cRepairCost ,
                                              AV11cTechnicianId ,
                                              AV12cRepairAlternateTechnicianId ,
                                              A23RepairDateFrom ,
                                              A24RepairDaysQuantity ,
                                              A16GameId ,
                                              A26RepairCost ,
                                              A27TechnicianId ,
                                              A29RepairAlternateTechnicianId ,
                                              AV6cRepairId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H000Q3 */
         pr_default.execute(1, new Object[] {AV6cRepairId, AV7cRepairDateFrom, AV8cRepairDaysQuantity, AV9cGameId, AV10cRepairCost, AV11cTechnicianId, AV12cRepairAlternateTechnicianId});
         GRID1_nRecordCount = H000Q3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRepairId, AV7cRepairDateFrom, AV8cRepairDaysQuantity, AV9cGameId, AV10cRepairCost, AV11cTechnicianId, AV12cRepairAlternateTechnicianId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRepairId, AV7cRepairDateFrom, AV8cRepairDaysQuantity, AV9cGameId, AV10cRepairCost, AV11cTechnicianId, AV12cRepairAlternateTechnicianId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRepairId, AV7cRepairDateFrom, AV8cRepairDaysQuantity, AV9cGameId, AV10cRepairCost, AV11cTechnicianId, AV12cRepairAlternateTechnicianId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRepairId, AV7cRepairDateFrom, AV8cRepairDaysQuantity, AV9cGameId, AV10cRepairCost, AV11cTechnicianId, AV12cRepairAlternateTechnicianId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRepairId, AV7cRepairDateFrom, AV8cRepairDaysQuantity, AV9cGameId, AV10cRepairCost, AV11cTechnicianId, AV12cRepairAlternateTechnicianId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrepairid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrepairid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCREPAIRID");
               GX_FocusControl = edtavCrepairid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cRepairId = 0;
               AssignAttri("", false, "AV6cRepairId", StringUtil.LTrimStr( (decimal)(AV6cRepairId), 4, 0));
            }
            else
            {
               AV6cRepairId = (short)(context.localUtil.CToN( cgiGet( edtavCrepairid_Internalname), ".", ","));
               AssignAttri("", false, "AV6cRepairId", StringUtil.LTrimStr( (decimal)(AV6cRepairId), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCrepairdatefrom_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Repair Date From"}), 1, "vCREPAIRDATEFROM");
               GX_FocusControl = edtavCrepairdatefrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cRepairDateFrom = DateTime.MinValue;
               AssignAttri("", false, "AV7cRepairDateFrom", context.localUtil.Format(AV7cRepairDateFrom, "99/99/99"));
            }
            else
            {
               AV7cRepairDateFrom = context.localUtil.CToD( cgiGet( edtavCrepairdatefrom_Internalname), 1);
               AssignAttri("", false, "AV7cRepairDateFrom", context.localUtil.Format(AV7cRepairDateFrom, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrepairdaysquantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrepairdaysquantity_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCREPAIRDAYSQUANTITY");
               GX_FocusControl = edtavCrepairdaysquantity_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cRepairDaysQuantity = 0;
               AssignAttri("", false, "AV8cRepairDaysQuantity", StringUtil.LTrimStr( (decimal)(AV8cRepairDaysQuantity), 4, 0));
            }
            else
            {
               AV8cRepairDaysQuantity = (short)(context.localUtil.CToN( cgiGet( edtavCrepairdaysquantity_Internalname), ".", ","));
               AssignAttri("", false, "AV8cRepairDaysQuantity", StringUtil.LTrimStr( (decimal)(AV8cRepairDaysQuantity), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCgameid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCgameid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCGAMEID");
               GX_FocusControl = edtavCgameid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cGameId = 0;
               AssignAttri("", false, "AV9cGameId", StringUtil.LTrimStr( (decimal)(AV9cGameId), 4, 0));
            }
            else
            {
               AV9cGameId = (short)(context.localUtil.CToN( cgiGet( edtavCgameid_Internalname), ".", ","));
               AssignAttri("", false, "AV9cGameId", StringUtil.LTrimStr( (decimal)(AV9cGameId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrepaircost_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrepaircost_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCREPAIRCOST");
               GX_FocusControl = edtavCrepaircost_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cRepairCost = 0;
               AssignAttri("", false, "AV10cRepairCost", StringUtil.LTrimStr( (decimal)(AV10cRepairCost), 4, 0));
            }
            else
            {
               AV10cRepairCost = (short)(context.localUtil.CToN( cgiGet( edtavCrepaircost_Internalname), ".", ","));
               AssignAttri("", false, "AV10cRepairCost", StringUtil.LTrimStr( (decimal)(AV10cRepairCost), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtechnicianid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtechnicianid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTECHNICIANID");
               GX_FocusControl = edtavCtechnicianid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cTechnicianId = 0;
               AssignAttri("", false, "AV11cTechnicianId", StringUtil.LTrimStr( (decimal)(AV11cTechnicianId), 4, 0));
            }
            else
            {
               AV11cTechnicianId = (short)(context.localUtil.CToN( cgiGet( edtavCtechnicianid_Internalname), ".", ","));
               AssignAttri("", false, "AV11cTechnicianId", StringUtil.LTrimStr( (decimal)(AV11cTechnicianId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrepairalternatetechnicianid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrepairalternatetechnicianid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCREPAIRALTERNATETECHNICIANID");
               GX_FocusControl = edtavCrepairalternatetechnicianid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cRepairAlternateTechnicianId = 0;
               AssignAttri("", false, "AV12cRepairAlternateTechnicianId", StringUtil.LTrimStr( (decimal)(AV12cRepairAlternateTechnicianId), 4, 0));
            }
            else
            {
               AV12cRepairAlternateTechnicianId = (short)(context.localUtil.CToN( cgiGet( edtavCrepairalternatetechnicianid_Internalname), ".", ","));
               AssignAttri("", false, "AV12cRepairAlternateTechnicianId", StringUtil.LTrimStr( (decimal)(AV12cRepairAlternateTechnicianId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREPAIRID"), ".", ",") != Convert.ToDecimal( AV6cRepairId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCREPAIRDATEFROM"), 1) ) != DateTimeUtil.ResetTime ( AV7cRepairDateFrom ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREPAIRDAYSQUANTITY"), ".", ",") != Convert.ToDecimal( AV8cRepairDaysQuantity )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCGAMEID"), ".", ",") != Convert.ToDecimal( AV9cGameId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREPAIRCOST"), ".", ",") != Convert.ToDecimal( AV10cRepairCost )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTECHNICIANID"), ".", ",") != Convert.ToDecimal( AV11cTechnicianId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREPAIRALTERNATETECHNICIANID"), ".", ",") != Convert.ToDecimal( AV12cRepairAlternateTechnicianId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E190Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Repair", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200Q2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E210Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210Q2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pRepairId = A22RepairId;
         AssignAttri("", false, "AV13pRepairId", StringUtil.LTrimStr( (decimal)(AV13pRepairId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pRepairId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pRepairId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pRepairId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pRepairId", StringUtil.LTrimStr( (decimal)(AV13pRepairId), 4, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0Q2( ) ;
         WS0Q2( ) ;
         WE0Q2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202361614433773", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx0070.js", "?202361614433774", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtRepairId_Internalname = "REPAIRID_"+sGXsfl_84_idx;
         edtRepairDateFrom_Internalname = "REPAIRDATEFROM_"+sGXsfl_84_idx;
         edtRepairDaysQuantity_Internalname = "REPAIRDAYSQUANTITY_"+sGXsfl_84_idx;
         edtGameId_Internalname = "GAMEID_"+sGXsfl_84_idx;
         edtRepairCost_Internalname = "REPAIRCOST_"+sGXsfl_84_idx;
         edtTechnicianId_Internalname = "TECHNICIANID_"+sGXsfl_84_idx;
         edtRepairAlternateTechnicianId_Internalname = "REPAIRALTERNATETECHNICIANID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtRepairId_Internalname = "REPAIRID_"+sGXsfl_84_fel_idx;
         edtRepairDateFrom_Internalname = "REPAIRDATEFROM_"+sGXsfl_84_fel_idx;
         edtRepairDaysQuantity_Internalname = "REPAIRDAYSQUANTITY_"+sGXsfl_84_fel_idx;
         edtGameId_Internalname = "GAMEID_"+sGXsfl_84_fel_idx;
         edtRepairCost_Internalname = "REPAIRCOST_"+sGXsfl_84_fel_idx;
         edtTechnicianId_Internalname = "TECHNICIANID_"+sGXsfl_84_fel_idx;
         edtRepairAlternateTechnicianId_Internalname = "REPAIRALTERNATETECHNICIANID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0Q0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22RepairId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepairId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22RepairId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22RepairId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepairId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtRepairDateFrom_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22RepairId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtRepairDateFrom_Internalname, "Link", edtRepairDateFrom_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepairDateFrom_Internalname,context.localUtil.Format(A23RepairDateFrom, "99/99/99"),context.localUtil.Format( A23RepairDateFrom, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtRepairDateFrom_Link,(string)"",(string)"",(string)"",(string)edtRepairDateFrom_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepairDaysQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RepairDaysQuantity), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A24RepairDaysQuantity), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepairDaysQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtGameId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16GameId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16GameId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtGameId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepairCost_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26RepairCost), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A26RepairCost), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepairCost_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTechnicianId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A27TechnicianId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A27TechnicianId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTechnicianId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepairAlternateTechnicianId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29RepairAlternateTechnicianId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A29RepairAlternateTechnicianId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepairAlternateTechnicianId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0Q2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblrepairidfilter_Internalname = "LBLREPAIRIDFILTER";
         edtavCrepairid_Internalname = "vCREPAIRID";
         divRepairidfiltercontainer_Internalname = "REPAIRIDFILTERCONTAINER";
         lblLblrepairdatefromfilter_Internalname = "LBLREPAIRDATEFROMFILTER";
         edtavCrepairdatefrom_Internalname = "vCREPAIRDATEFROM";
         divRepairdatefromfiltercontainer_Internalname = "REPAIRDATEFROMFILTERCONTAINER";
         lblLblrepairdaysquantityfilter_Internalname = "LBLREPAIRDAYSQUANTITYFILTER";
         edtavCrepairdaysquantity_Internalname = "vCREPAIRDAYSQUANTITY";
         divRepairdaysquantityfiltercontainer_Internalname = "REPAIRDAYSQUANTITYFILTERCONTAINER";
         lblLblgameidfilter_Internalname = "LBLGAMEIDFILTER";
         edtavCgameid_Internalname = "vCGAMEID";
         divGameidfiltercontainer_Internalname = "GAMEIDFILTERCONTAINER";
         lblLblrepaircostfilter_Internalname = "LBLREPAIRCOSTFILTER";
         edtavCrepaircost_Internalname = "vCREPAIRCOST";
         divRepaircostfiltercontainer_Internalname = "REPAIRCOSTFILTERCONTAINER";
         lblLbltechnicianidfilter_Internalname = "LBLTECHNICIANIDFILTER";
         edtavCtechnicianid_Internalname = "vCTECHNICIANID";
         divTechnicianidfiltercontainer_Internalname = "TECHNICIANIDFILTERCONTAINER";
         lblLblrepairalternatetechnicianidfilter_Internalname = "LBLREPAIRALTERNATETECHNICIANIDFILTER";
         edtavCrepairalternatetechnicianid_Internalname = "vCREPAIRALTERNATETECHNICIANID";
         divRepairalternatetechnicianidfiltercontainer_Internalname = "REPAIRALTERNATETECHNICIANIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtRepairId_Internalname = "REPAIRID";
         edtRepairDateFrom_Internalname = "REPAIRDATEFROM";
         edtRepairDaysQuantity_Internalname = "REPAIRDAYSQUANTITY";
         edtGameId_Internalname = "GAMEID";
         edtRepairCost_Internalname = "REPAIRCOST";
         edtTechnicianId_Internalname = "TECHNICIANID";
         edtRepairAlternateTechnicianId_Internalname = "REPAIRALTERNATETECHNICIANID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtRepairAlternateTechnicianId_Jsonclick = "";
         edtTechnicianId_Jsonclick = "";
         edtRepairCost_Jsonclick = "";
         edtGameId_Jsonclick = "";
         edtRepairDaysQuantity_Jsonclick = "";
         edtRepairDateFrom_Jsonclick = "";
         edtRepairId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtRepairDateFrom_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCrepairalternatetechnicianid_Jsonclick = "";
         edtavCrepairalternatetechnicianid_Enabled = 1;
         edtavCrepairalternatetechnicianid_Visible = 1;
         edtavCtechnicianid_Jsonclick = "";
         edtavCtechnicianid_Enabled = 1;
         edtavCtechnicianid_Visible = 1;
         edtavCrepaircost_Jsonclick = "";
         edtavCrepaircost_Enabled = 1;
         edtavCrepaircost_Visible = 1;
         edtavCgameid_Jsonclick = "";
         edtavCgameid_Enabled = 1;
         edtavCgameid_Visible = 1;
         edtavCrepairdaysquantity_Jsonclick = "";
         edtavCrepairdaysquantity_Enabled = 1;
         edtavCrepairdaysquantity_Visible = 1;
         edtavCrepairdatefrom_Jsonclick = "";
         edtavCrepairdatefrom_Enabled = 1;
         edtavCrepairid_Jsonclick = "";
         edtavCrepairid_Enabled = 1;
         edtavCrepairid_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Repair";
         divRepairalternatetechnicianidfiltercontainer_Class = "AdvancedContainerItem";
         divTechnicianidfiltercontainer_Class = "AdvancedContainerItem";
         divRepaircostfiltercontainer_Class = "AdvancedContainerItem";
         divGameidfiltercontainer_Class = "AdvancedContainerItem";
         divRepairdaysquantityfiltercontainer_Class = "AdvancedContainerItem";
         divRepairdatefromfiltercontainer_Class = "AdvancedContainerItem";
         divRepairidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRepairId',fld:'vCREPAIRID',pic:'ZZZ9'},{av:'AV7cRepairDateFrom',fld:'vCREPAIRDATEFROM',pic:''},{av:'AV8cRepairDaysQuantity',fld:'vCREPAIRDAYSQUANTITY',pic:'ZZZ9'},{av:'AV9cGameId',fld:'vCGAMEID',pic:'ZZZ9'},{av:'AV10cRepairCost',fld:'vCREPAIRCOST',pic:'ZZZ9'},{av:'AV11cTechnicianId',fld:'vCTECHNICIANID',pic:'ZZZ9'},{av:'AV12cRepairAlternateTechnicianId',fld:'vCREPAIRALTERNATETECHNICIANID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180Q1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLREPAIRIDFILTER.CLICK","{handler:'E110Q1',iparms:[{av:'divRepairidfiltercontainer_Class',ctrl:'REPAIRIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREPAIRIDFILTER.CLICK",",oparms:[{av:'divRepairidfiltercontainer_Class',ctrl:'REPAIRIDFILTERCONTAINER',prop:'Class'},{av:'edtavCrepairid_Visible',ctrl:'vCREPAIRID',prop:'Visible'}]}");
         setEventMetadata("LBLREPAIRDATEFROMFILTER.CLICK","{handler:'E120Q1',iparms:[{av:'divRepairdatefromfiltercontainer_Class',ctrl:'REPAIRDATEFROMFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREPAIRDATEFROMFILTER.CLICK",",oparms:[{av:'divRepairdatefromfiltercontainer_Class',ctrl:'REPAIRDATEFROMFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLREPAIRDAYSQUANTITYFILTER.CLICK","{handler:'E130Q1',iparms:[{av:'divRepairdaysquantityfiltercontainer_Class',ctrl:'REPAIRDAYSQUANTITYFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREPAIRDAYSQUANTITYFILTER.CLICK",",oparms:[{av:'divRepairdaysquantityfiltercontainer_Class',ctrl:'REPAIRDAYSQUANTITYFILTERCONTAINER',prop:'Class'},{av:'edtavCrepairdaysquantity_Visible',ctrl:'vCREPAIRDAYSQUANTITY',prop:'Visible'}]}");
         setEventMetadata("LBLGAMEIDFILTER.CLICK","{handler:'E140Q1',iparms:[{av:'divGameidfiltercontainer_Class',ctrl:'GAMEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLGAMEIDFILTER.CLICK",",oparms:[{av:'divGameidfiltercontainer_Class',ctrl:'GAMEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCgameid_Visible',ctrl:'vCGAMEID',prop:'Visible'}]}");
         setEventMetadata("LBLREPAIRCOSTFILTER.CLICK","{handler:'E150Q1',iparms:[{av:'divRepaircostfiltercontainer_Class',ctrl:'REPAIRCOSTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREPAIRCOSTFILTER.CLICK",",oparms:[{av:'divRepaircostfiltercontainer_Class',ctrl:'REPAIRCOSTFILTERCONTAINER',prop:'Class'},{av:'edtavCrepaircost_Visible',ctrl:'vCREPAIRCOST',prop:'Visible'}]}");
         setEventMetadata("LBLTECHNICIANIDFILTER.CLICK","{handler:'E160Q1',iparms:[{av:'divTechnicianidfiltercontainer_Class',ctrl:'TECHNICIANIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTECHNICIANIDFILTER.CLICK",",oparms:[{av:'divTechnicianidfiltercontainer_Class',ctrl:'TECHNICIANIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtechnicianid_Visible',ctrl:'vCTECHNICIANID',prop:'Visible'}]}");
         setEventMetadata("LBLREPAIRALTERNATETECHNICIANIDFILTER.CLICK","{handler:'E170Q1',iparms:[{av:'divRepairalternatetechnicianidfiltercontainer_Class',ctrl:'REPAIRALTERNATETECHNICIANIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLREPAIRALTERNATETECHNICIANIDFILTER.CLICK",",oparms:[{av:'divRepairalternatetechnicianidfiltercontainer_Class',ctrl:'REPAIRALTERNATETECHNICIANIDFILTERCONTAINER',prop:'Class'},{av:'edtavCrepairalternatetechnicianid_Visible',ctrl:'vCREPAIRALTERNATETECHNICIANID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210Q2',iparms:[{av:'A22RepairId',fld:'REPAIRID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pRepairId',fld:'vPREPAIRID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRepairId',fld:'vCREPAIRID',pic:'ZZZ9'},{av:'AV7cRepairDateFrom',fld:'vCREPAIRDATEFROM',pic:''},{av:'AV8cRepairDaysQuantity',fld:'vCREPAIRDAYSQUANTITY',pic:'ZZZ9'},{av:'AV9cGameId',fld:'vCGAMEID',pic:'ZZZ9'},{av:'AV10cRepairCost',fld:'vCREPAIRCOST',pic:'ZZZ9'},{av:'AV11cTechnicianId',fld:'vCTECHNICIANID',pic:'ZZZ9'},{av:'AV12cRepairAlternateTechnicianId',fld:'vCREPAIRALTERNATETECHNICIANID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRepairId',fld:'vCREPAIRID',pic:'ZZZ9'},{av:'AV7cRepairDateFrom',fld:'vCREPAIRDATEFROM',pic:''},{av:'AV8cRepairDaysQuantity',fld:'vCREPAIRDAYSQUANTITY',pic:'ZZZ9'},{av:'AV9cGameId',fld:'vCGAMEID',pic:'ZZZ9'},{av:'AV10cRepairCost',fld:'vCREPAIRCOST',pic:'ZZZ9'},{av:'AV11cTechnicianId',fld:'vCTECHNICIANID',pic:'ZZZ9'},{av:'AV12cRepairAlternateTechnicianId',fld:'vCREPAIRALTERNATETECHNICIANID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRepairId',fld:'vCREPAIRID',pic:'ZZZ9'},{av:'AV7cRepairDateFrom',fld:'vCREPAIRDATEFROM',pic:''},{av:'AV8cRepairDaysQuantity',fld:'vCREPAIRDAYSQUANTITY',pic:'ZZZ9'},{av:'AV9cGameId',fld:'vCGAMEID',pic:'ZZZ9'},{av:'AV10cRepairCost',fld:'vCREPAIRCOST',pic:'ZZZ9'},{av:'AV11cTechnicianId',fld:'vCTECHNICIANID',pic:'ZZZ9'},{av:'AV12cRepairAlternateTechnicianId',fld:'vCREPAIRALTERNATETECHNICIANID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRepairId',fld:'vCREPAIRID',pic:'ZZZ9'},{av:'AV7cRepairDateFrom',fld:'vCREPAIRDATEFROM',pic:''},{av:'AV8cRepairDaysQuantity',fld:'vCREPAIRDAYSQUANTITY',pic:'ZZZ9'},{av:'AV9cGameId',fld:'vCGAMEID',pic:'ZZZ9'},{av:'AV10cRepairCost',fld:'vCREPAIRCOST',pic:'ZZZ9'},{av:'AV11cTechnicianId',fld:'vCTECHNICIANID',pic:'ZZZ9'},{av:'AV12cRepairAlternateTechnicianId',fld:'vCREPAIRALTERNATETECHNICIANID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CREPAIRDATEFROM","{handler:'Validv_Crepairdatefrom',iparms:[]");
         setEventMetadata("VALIDV_CREPAIRDATEFROM",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Repairalternatetechnicianid',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cRepairDateFrom = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblrepairidfilter_Jsonclick = "";
         TempTags = "";
         lblLblrepairdatefromfilter_Jsonclick = "";
         lblLblrepairdaysquantityfilter_Jsonclick = "";
         lblLblgameidfilter_Jsonclick = "";
         lblLblrepaircostfilter_Jsonclick = "";
         lblLbltechnicianidfilter_Jsonclick = "";
         lblLblrepairalternatetechnicianidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A23RepairDateFrom = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         H000Q2_A29RepairAlternateTechnicianId = new short[1] ;
         H000Q2_A27TechnicianId = new short[1] ;
         H000Q2_A26RepairCost = new short[1] ;
         H000Q2_A16GameId = new short[1] ;
         H000Q2_A24RepairDaysQuantity = new short[1] ;
         H000Q2_A23RepairDateFrom = new DateTime[] {DateTime.MinValue} ;
         H000Q2_A22RepairId = new short[1] ;
         H000Q3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0070__default(),
            new Object[][] {
                new Object[] {
               H000Q2_A29RepairAlternateTechnicianId, H000Q2_A27TechnicianId, H000Q2_A26RepairCost, H000Q2_A16GameId, H000Q2_A24RepairDaysQuantity, H000Q2_A23RepairDateFrom, H000Q2_A22RepairId
               }
               , new Object[] {
               H000Q3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pRepairId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cRepairId ;
      private short AV8cRepairDaysQuantity ;
      private short AV9cGameId ;
      private short AV10cRepairCost ;
      private short AV11cTechnicianId ;
      private short AV12cRepairAlternateTechnicianId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A22RepairId ;
      private short A24RepairDaysQuantity ;
      private short A16GameId ;
      private short A26RepairCost ;
      private short A27TechnicianId ;
      private short A29RepairAlternateTechnicianId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCrepairid_Enabled ;
      private int edtavCrepairid_Visible ;
      private int edtavCrepairdatefrom_Enabled ;
      private int edtavCrepairdaysquantity_Enabled ;
      private int edtavCrepairdaysquantity_Visible ;
      private int edtavCgameid_Enabled ;
      private int edtavCgameid_Visible ;
      private int edtavCrepaircost_Enabled ;
      private int edtavCrepaircost_Visible ;
      private int edtavCtechnicianid_Enabled ;
      private int edtavCtechnicianid_Visible ;
      private int edtavCrepairalternatetechnicianid_Enabled ;
      private int edtavCrepairalternatetechnicianid_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divRepairidfiltercontainer_Class ;
      private string divRepairdatefromfiltercontainer_Class ;
      private string divRepairdaysquantityfiltercontainer_Class ;
      private string divGameidfiltercontainer_Class ;
      private string divRepaircostfiltercontainer_Class ;
      private string divTechnicianidfiltercontainer_Class ;
      private string divRepairalternatetechnicianidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divRepairidfiltercontainer_Internalname ;
      private string lblLblrepairidfilter_Internalname ;
      private string lblLblrepairidfilter_Jsonclick ;
      private string edtavCrepairid_Internalname ;
      private string TempTags ;
      private string edtavCrepairid_Jsonclick ;
      private string divRepairdatefromfiltercontainer_Internalname ;
      private string lblLblrepairdatefromfilter_Internalname ;
      private string lblLblrepairdatefromfilter_Jsonclick ;
      private string edtavCrepairdatefrom_Internalname ;
      private string edtavCrepairdatefrom_Jsonclick ;
      private string divRepairdaysquantityfiltercontainer_Internalname ;
      private string lblLblrepairdaysquantityfilter_Internalname ;
      private string lblLblrepairdaysquantityfilter_Jsonclick ;
      private string edtavCrepairdaysquantity_Internalname ;
      private string edtavCrepairdaysquantity_Jsonclick ;
      private string divGameidfiltercontainer_Internalname ;
      private string lblLblgameidfilter_Internalname ;
      private string lblLblgameidfilter_Jsonclick ;
      private string edtavCgameid_Internalname ;
      private string edtavCgameid_Jsonclick ;
      private string divRepaircostfiltercontainer_Internalname ;
      private string lblLblrepaircostfilter_Internalname ;
      private string lblLblrepaircostfilter_Jsonclick ;
      private string edtavCrepaircost_Internalname ;
      private string edtavCrepaircost_Jsonclick ;
      private string divTechnicianidfiltercontainer_Internalname ;
      private string lblLbltechnicianidfilter_Internalname ;
      private string lblLbltechnicianidfilter_Jsonclick ;
      private string edtavCtechnicianid_Internalname ;
      private string edtavCtechnicianid_Jsonclick ;
      private string divRepairalternatetechnicianidfiltercontainer_Internalname ;
      private string lblLblrepairalternatetechnicianidfilter_Internalname ;
      private string lblLblrepairalternatetechnicianidfilter_Jsonclick ;
      private string edtavCrepairalternatetechnicianid_Internalname ;
      private string edtavCrepairalternatetechnicianid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string edtRepairDateFrom_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtRepairId_Internalname ;
      private string edtRepairDateFrom_Internalname ;
      private string edtRepairDaysQuantity_Internalname ;
      private string edtGameId_Internalname ;
      private string edtRepairCost_Internalname ;
      private string edtTechnicianId_Internalname ;
      private string edtRepairAlternateTechnicianId_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtRepairId_Jsonclick ;
      private string edtRepairDateFrom_Jsonclick ;
      private string edtRepairDaysQuantity_Jsonclick ;
      private string edtGameId_Jsonclick ;
      private string edtRepairCost_Jsonclick ;
      private string edtTechnicianId_Jsonclick ;
      private string edtRepairAlternateTechnicianId_Jsonclick ;
      private DateTime AV7cRepairDateFrom ;
      private DateTime A23RepairDateFrom ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000Q2_A29RepairAlternateTechnicianId ;
      private short[] H000Q2_A27TechnicianId ;
      private short[] H000Q2_A26RepairCost ;
      private short[] H000Q2_A16GameId ;
      private short[] H000Q2_A24RepairDaysQuantity ;
      private DateTime[] H000Q2_A23RepairDateFrom ;
      private short[] H000Q2_A22RepairId ;
      private long[] H000Q3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pRepairId ;
      private GXWebForm Form ;
   }

   public class gx0070__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000Q2( IGxContext context ,
                                             DateTime AV7cRepairDateFrom ,
                                             short AV8cRepairDaysQuantity ,
                                             short AV9cGameId ,
                                             short AV10cRepairCost ,
                                             short AV11cTechnicianId ,
                                             short AV12cRepairAlternateTechnicianId ,
                                             DateTime A23RepairDateFrom ,
                                             short A24RepairDaysQuantity ,
                                             short A16GameId ,
                                             short A26RepairCost ,
                                             short A27TechnicianId ,
                                             short A29RepairAlternateTechnicianId ,
                                             short AV6cRepairId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [RepairAlternateTechnicianId], [TechnicianId], [RepairCost], [GameId], [RepairDaysQuantity], [RepairDateFrom], [RepairId]";
         sFromString = " FROM [Repair]";
         sOrderString = "";
         AddWhere(sWhereString, "([RepairId] >= @AV6cRepairId)");
         if ( ! (DateTime.MinValue==AV7cRepairDateFrom) )
         {
            AddWhere(sWhereString, "([RepairDateFrom] >= @AV7cRepairDateFrom)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cRepairDaysQuantity) )
         {
            AddWhere(sWhereString, "([RepairDaysQuantity] >= @AV8cRepairDaysQuantity)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cGameId) )
         {
            AddWhere(sWhereString, "([GameId] >= @AV9cGameId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cRepairCost) )
         {
            AddWhere(sWhereString, "([RepairCost] >= @AV10cRepairCost)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cTechnicianId) )
         {
            AddWhere(sWhereString, "([TechnicianId] >= @AV11cTechnicianId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cRepairAlternateTechnicianId) )
         {
            AddWhere(sWhereString, "([RepairAlternateTechnicianId] >= @AV12cRepairAlternateTechnicianId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [RepairId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000Q3( IGxContext context ,
                                             DateTime AV7cRepairDateFrom ,
                                             short AV8cRepairDaysQuantity ,
                                             short AV9cGameId ,
                                             short AV10cRepairCost ,
                                             short AV11cTechnicianId ,
                                             short AV12cRepairAlternateTechnicianId ,
                                             DateTime A23RepairDateFrom ,
                                             short A24RepairDaysQuantity ,
                                             short A16GameId ,
                                             short A26RepairCost ,
                                             short A27TechnicianId ,
                                             short A29RepairAlternateTechnicianId ,
                                             short AV6cRepairId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Repair]";
         AddWhere(sWhereString, "([RepairId] >= @AV6cRepairId)");
         if ( ! (DateTime.MinValue==AV7cRepairDateFrom) )
         {
            AddWhere(sWhereString, "([RepairDateFrom] >= @AV7cRepairDateFrom)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cRepairDaysQuantity) )
         {
            AddWhere(sWhereString, "([RepairDaysQuantity] >= @AV8cRepairDaysQuantity)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cGameId) )
         {
            AddWhere(sWhereString, "([GameId] >= @AV9cGameId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cRepairCost) )
         {
            AddWhere(sWhereString, "([RepairCost] >= @AV10cRepairCost)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cTechnicianId) )
         {
            AddWhere(sWhereString, "([TechnicianId] >= @AV11cTechnicianId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cRepairAlternateTechnicianId) )
         {
            AddWhere(sWhereString, "([RepairAlternateTechnicianId] >= @AV12cRepairAlternateTechnicianId)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000Q2(context, (DateTime)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H000Q3(context, (DateTime)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000Q2;
          prmH000Q2 = new Object[] {
          new ParDef("@AV6cRepairId",GXType.Int16,4,0) ,
          new ParDef("@AV7cRepairDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV8cRepairDaysQuantity",GXType.Int16,4,0) ,
          new ParDef("@AV9cGameId",GXType.Int16,4,0) ,
          new ParDef("@AV10cRepairCost",GXType.Int16,4,0) ,
          new ParDef("@AV11cTechnicianId",GXType.Int16,4,0) ,
          new ParDef("@AV12cRepairAlternateTechnicianId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000Q3;
          prmH000Q3 = new Object[] {
          new ParDef("@AV6cRepairId",GXType.Int16,4,0) ,
          new ParDef("@AV7cRepairDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV8cRepairDaysQuantity",GXType.Int16,4,0) ,
          new ParDef("@AV9cGameId",GXType.Int16,4,0) ,
          new ParDef("@AV10cRepairCost",GXType.Int16,4,0) ,
          new ParDef("@AV11cTechnicianId",GXType.Int16,4,0) ,
          new ParDef("@AV12cRepairAlternateTechnicianId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Q3,1, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
