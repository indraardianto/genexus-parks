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
   public class gx0020 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0020( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0020( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pAmusementParkId )
      {
         this.AV10pAmusementParkId = 0 ;
         executePrivate();
         aP0_pAmusementParkId=this.AV10pAmusementParkId;
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
            gxfirstwebparm = GetFirstPar( "pAmusementParkId");
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
               gxfirstwebparm = GetFirstPar( "pAmusementParkId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pAmusementParkId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_64 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."));
               nGXsfl_64_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."));
               sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
               AV6cAmusementParkId = (short)(NumberUtil.Val( GetPar( "cAmusementParkId"), "."));
               AV7cAmusementParkName = GetPar( "cAmusementParkName");
               AV8cAmusementParkWebsite = GetPar( "cAmusementParkWebsite");
               AV9cCountryId = (short)(NumberUtil.Val( GetPar( "cCountryId"), "."));
               AV12cCityId = (short)(NumberUtil.Val( GetPar( "cCityId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cAmusementParkId, AV7cAmusementParkName, AV8cAmusementParkWebsite, AV9cCountryId, AV12cCityId) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKIDFILTERCONTAINER_Class", StringUtil.RTrim( divAmusementparkidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divAmusementparknamefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKWEBSITEFILTERCONTAINER_Class", StringUtil.RTrim( divAmusementparkwebsitefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "COUNTRYIDFILTERCONTAINER_Class", StringUtil.RTrim( divCountryidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "CITYIDFILTERCONTAINER_Class", StringUtil.RTrim( divCityidfiltercontainer_Class));
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
               AV10pAmusementParkId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV10pAmusementParkId", StringUtil.LTrimStr( (decimal)(AV10pAmusementParkId), 4, 0));
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
         PA082( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START082( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202361613353552", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0020.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pAmusementParkId,4,0))}, new string[] {"pAmusementParkId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCAMUSEMENTPARKID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cAmusementParkId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCAMUSEMENTPARKNAME", StringUtil.RTrim( AV7cAmusementParkName));
         GxWebStd.gx_hidden_field( context, "GXH_vCAMUSEMENTPARKWEBSITE", StringUtil.RTrim( AV8cAmusementParkWebsite));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cCountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cCityId), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPAMUSEMENTPARKID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pAmusementParkId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKIDFILTERCONTAINER_Class", StringUtil.RTrim( divAmusementparkidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divAmusementparknamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKWEBSITEFILTERCONTAINER_Class", StringUtil.RTrim( divAmusementparkwebsitefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COUNTRYIDFILTERCONTAINER_Class", StringUtil.RTrim( divCountryidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CITYIDFILTERCONTAINER_Class", StringUtil.RTrim( divCityidfiltercontainer_Class));
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
            WE082( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT082( ) ;
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
         return formatLink("gx0020.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pAmusementParkId,4,0))}, new string[] {"pAmusementParkId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0020" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Amusement Park" ;
      }

      protected void WB080( )
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
            GxWebStd.gx_div_start( context, divAmusementparkidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divAmusementparkidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblamusementparkidfilter_Internalname, "Amusement Park Id", "", "", lblLblamusementparkidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCamusementparkid_Internalname, "Amusement Park Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCamusementparkid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cAmusementParkId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCamusementparkid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cAmusementParkId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cAmusementParkId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCamusementparkid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCamusementparkid_Visible, edtavCamusementparkid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0020.htm");
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
            GxWebStd.gx_div_start( context, divAmusementparknamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divAmusementparknamefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblamusementparknamefilter_Internalname, "Amusement Park Name", "", "", lblLblamusementparknamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCamusementparkname_Internalname, "Amusement Park Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCamusementparkname_Internalname, StringUtil.RTrim( AV7cAmusementParkName), StringUtil.RTrim( context.localUtil.Format( AV7cAmusementParkName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCamusementparkname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCamusementparkname_Visible, edtavCamusementparkname_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0020.htm");
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
            GxWebStd.gx_div_start( context, divAmusementparkwebsitefiltercontainer_Internalname, 1, 0, "px", 0, "px", divAmusementparkwebsitefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblamusementparkwebsitefilter_Internalname, "Amusement Park Website", "", "", lblLblamusementparkwebsitefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCamusementparkwebsite_Internalname, "Amusement Park Website", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCamusementparkwebsite_Internalname, StringUtil.RTrim( AV8cAmusementParkWebsite), StringUtil.RTrim( context.localUtil.Format( AV8cAmusementParkWebsite, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCamusementparkwebsite_Jsonclick, 0, "Attribute", "", "", "", "", edtavCamusementparkwebsite_Visible, edtavCamusementparkwebsite_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0020.htm");
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
            GxWebStd.gx_div_start( context, divCountryidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCountryidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcountryidfilter_Internalname, "Country Id", "", "", lblLblcountryidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcountryid_Internalname, "Country Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcountryid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cCountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCcountryid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cCountryId), "ZZZ9") : context.localUtil.Format( (decimal)(AV9cCountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcountryid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcountryid_Visible, edtavCcountryid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0020.htm");
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
            GxWebStd.gx_div_start( context, divCityidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCityidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcityidfilter_Internalname, "City Id", "", "", lblLblcityidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcityid_Internalname, "City Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcityid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cCityId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCcityid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cCityId), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cCityId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcityid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcityid_Visible, edtavCcityid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0020.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16081_client"+"'", TempTags, "", 2, "HLP_Gx0020.htm");
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
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
               context.SendWebValue( "Park Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Park Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Park Website") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Park Photo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "City Id") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A8AmusementParkName));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtAmusementParkName_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A9AmusementParkWebsite));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( A11AmusementParkPhoto));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19CityId), 4, 0, ".", "")));
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
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void START082( )
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
            Form.Meta.addItem("description", "Selection List Amusement Park", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP080( ) ;
      }

      protected void WS082( )
      {
         START082( ) ;
         EVT082( ) ;
      }

      protected void EVT082( )
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
                              nGXsfl_64_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ","));
                              A8AmusementParkName = cgiGet( edtAmusementParkName_Internalname);
                              A9AmusementParkWebsite = cgiGet( edtAmusementParkWebsite_Internalname);
                              A11AmusementParkPhoto = cgiGet( edtAmusementParkPhoto_Internalname);
                              AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
                              A19CityId = (short)(context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ","));
                              n19CityId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Camusementparkid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCAMUSEMENTPARKID"), ".", ",") != Convert.ToDecimal( AV6cAmusementParkId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Camusementparkname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCAMUSEMENTPARKNAME"), AV7cAmusementParkName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Camusementparkwebsite Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCAMUSEMENTPARKWEBSITE"), AV8cAmusementParkWebsite) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccountryid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOUNTRYID"), ".", ",") != Convert.ToDecimal( AV9cCountryId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccityid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCITYID"), ".", ",") != Convert.ToDecimal( AV12cCityId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19082 ();
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

      protected void WE082( )
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

      protected void PA082( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cAmusementParkId ,
                                        string AV7cAmusementParkName ,
                                        string AV8cAmusementParkWebsite ,
                                        short AV9cCountryId ,
                                        short AV12cCityId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF082( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AMUSEMENTPARKID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")));
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
         RF082( ) ;
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

      protected void RF082( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cAmusementParkName ,
                                                 AV8cAmusementParkWebsite ,
                                                 AV9cCountryId ,
                                                 AV12cCityId ,
                                                 A8AmusementParkName ,
                                                 A9AmusementParkWebsite ,
                                                 A12CountryId ,
                                                 A19CityId ,
                                                 AV6cAmusementParkId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV7cAmusementParkName = StringUtil.PadR( StringUtil.RTrim( AV7cAmusementParkName), 20, "%");
            lV8cAmusementParkWebsite = StringUtil.PadR( StringUtil.RTrim( AV8cAmusementParkWebsite), 60, "%");
            /* Using cursor H00082 */
            pr_default.execute(0, new Object[] {AV6cAmusementParkId, lV7cAmusementParkName, lV8cAmusementParkWebsite, AV9cCountryId, AV12cCityId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A12CountryId = H00082_A12CountryId[0];
               A19CityId = H00082_A19CityId[0];
               n19CityId = H00082_n19CityId[0];
               A40000AmusementParkPhoto_GXI = H00082_A40000AmusementParkPhoto_GXI[0];
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_64_Refreshing);
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
               A9AmusementParkWebsite = H00082_A9AmusementParkWebsite[0];
               A8AmusementParkName = H00082_A8AmusementParkName[0];
               A7AmusementParkId = H00082_A7AmusementParkId[0];
               A11AmusementParkPhoto = H00082_A11AmusementParkPhoto[0];
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_64_Refreshing);
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
               /* Execute user event: Load */
               E18082 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB080( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes082( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AMUSEMENTPARKID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"), context));
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
                                              AV7cAmusementParkName ,
                                              AV8cAmusementParkWebsite ,
                                              AV9cCountryId ,
                                              AV12cCityId ,
                                              A8AmusementParkName ,
                                              A9AmusementParkWebsite ,
                                              A12CountryId ,
                                              A19CityId ,
                                              AV6cAmusementParkId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV7cAmusementParkName = StringUtil.PadR( StringUtil.RTrim( AV7cAmusementParkName), 20, "%");
         lV8cAmusementParkWebsite = StringUtil.PadR( StringUtil.RTrim( AV8cAmusementParkWebsite), 60, "%");
         /* Using cursor H00083 */
         pr_default.execute(1, new Object[] {AV6cAmusementParkId, lV7cAmusementParkName, lV8cAmusementParkWebsite, AV9cCountryId, AV12cCityId});
         GRID1_nRecordCount = H00083_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAmusementParkId, AV7cAmusementParkName, AV8cAmusementParkWebsite, AV9cCountryId, AV12cCityId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAmusementParkId, AV7cAmusementParkName, AV8cAmusementParkWebsite, AV9cCountryId, AV12cCityId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAmusementParkId, AV7cAmusementParkName, AV8cAmusementParkWebsite, AV9cCountryId, AV12cCityId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAmusementParkId, AV7cAmusementParkName, AV8cAmusementParkWebsite, AV9cCountryId, AV12cCityId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAmusementParkId, AV7cAmusementParkName, AV8cAmusementParkWebsite, AV9cCountryId, AV12cCityId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP080( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17082 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCamusementparkid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCamusementparkid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCAMUSEMENTPARKID");
               GX_FocusControl = edtavCamusementparkid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cAmusementParkId = 0;
               AssignAttri("", false, "AV6cAmusementParkId", StringUtil.LTrimStr( (decimal)(AV6cAmusementParkId), 4, 0));
            }
            else
            {
               AV6cAmusementParkId = (short)(context.localUtil.CToN( cgiGet( edtavCamusementparkid_Internalname), ".", ","));
               AssignAttri("", false, "AV6cAmusementParkId", StringUtil.LTrimStr( (decimal)(AV6cAmusementParkId), 4, 0));
            }
            AV7cAmusementParkName = cgiGet( edtavCamusementparkname_Internalname);
            AssignAttri("", false, "AV7cAmusementParkName", AV7cAmusementParkName);
            AV8cAmusementParkWebsite = cgiGet( edtavCamusementparkwebsite_Internalname);
            AssignAttri("", false, "AV8cAmusementParkWebsite", AV8cAmusementParkWebsite);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcountryid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcountryid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOUNTRYID");
               GX_FocusControl = edtavCcountryid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cCountryId = 0;
               AssignAttri("", false, "AV9cCountryId", StringUtil.LTrimStr( (decimal)(AV9cCountryId), 4, 0));
            }
            else
            {
               AV9cCountryId = (short)(context.localUtil.CToN( cgiGet( edtavCcountryid_Internalname), ".", ","));
               AssignAttri("", false, "AV9cCountryId", StringUtil.LTrimStr( (decimal)(AV9cCountryId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcityid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcityid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCITYID");
               GX_FocusControl = edtavCcityid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cCityId = 0;
               AssignAttri("", false, "AV12cCityId", StringUtil.LTrimStr( (decimal)(AV12cCityId), 4, 0));
            }
            else
            {
               AV12cCityId = (short)(context.localUtil.CToN( cgiGet( edtavCcityid_Internalname), ".", ","));
               AssignAttri("", false, "AV12cCityId", StringUtil.LTrimStr( (decimal)(AV12cCityId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCAMUSEMENTPARKID"), ".", ",") != Convert.ToDecimal( AV6cAmusementParkId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCAMUSEMENTPARKNAME"), AV7cAmusementParkName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCAMUSEMENTPARKWEBSITE"), AV8cAmusementParkWebsite) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOUNTRYID"), ".", ",") != Convert.ToDecimal( AV9cCountryId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCITYID"), ".", ",") != Convert.ToDecimal( AV12cCityId )) )
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
         E17082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17082( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Amusement Park", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV11ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E18082( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19082( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10pAmusementParkId = A7AmusementParkId;
         AssignAttri("", false, "AV10pAmusementParkId", StringUtil.LTrimStr( (decimal)(AV10pAmusementParkId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV10pAmusementParkId});
         context.setWebReturnParmsMetadata(new Object[] {"AV10pAmusementParkId"});
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
         AV10pAmusementParkId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV10pAmusementParkId", StringUtil.LTrimStr( (decimal)(AV10pAmusementParkId), 4, 0));
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
         PA082( ) ;
         WS082( ) ;
         WE082( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202361613353616", true, true);
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
         context.AddJavascriptSource("gx0020.js", "?202361613353616", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID_"+sGXsfl_64_idx;
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME_"+sGXsfl_64_idx;
         edtAmusementParkWebsite_Internalname = "AMUSEMENTPARKWEBSITE_"+sGXsfl_64_idx;
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO_"+sGXsfl_64_idx;
         edtCityId_Internalname = "CITYID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID_"+sGXsfl_64_fel_idx;
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME_"+sGXsfl_64_fel_idx;
         edtAmusementParkWebsite_Internalname = "AMUSEMENTPARKWEBSITE_"+sGXsfl_64_fel_idx;
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO_"+sGXsfl_64_fel_idx;
         edtCityId_Internalname = "CITYID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB080( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmusementParkId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtAmusementParkName_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtAmusementParkName_Internalname, "Link", edtAmusementParkName_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkName_Internalname,StringUtil.RTrim( A8AmusementParkName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtAmusementParkName_Link,(string)"",(string)"",(string)"",(string)edtAmusementParkName_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkWebsite_Internalname,StringUtil.RTrim( A9AmusementParkWebsite),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmusementParkWebsite_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A11AmusementParkPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AmusementParkPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.PathToRelativeUrl( A11AmusementParkPhoto));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A11AmusementParkPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19CityId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19CityId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes082( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblamusementparkidfilter_Internalname = "LBLAMUSEMENTPARKIDFILTER";
         edtavCamusementparkid_Internalname = "vCAMUSEMENTPARKID";
         divAmusementparkidfiltercontainer_Internalname = "AMUSEMENTPARKIDFILTERCONTAINER";
         lblLblamusementparknamefilter_Internalname = "LBLAMUSEMENTPARKNAMEFILTER";
         edtavCamusementparkname_Internalname = "vCAMUSEMENTPARKNAME";
         divAmusementparknamefiltercontainer_Internalname = "AMUSEMENTPARKNAMEFILTERCONTAINER";
         lblLblamusementparkwebsitefilter_Internalname = "LBLAMUSEMENTPARKWEBSITEFILTER";
         edtavCamusementparkwebsite_Internalname = "vCAMUSEMENTPARKWEBSITE";
         divAmusementparkwebsitefiltercontainer_Internalname = "AMUSEMENTPARKWEBSITEFILTERCONTAINER";
         lblLblcountryidfilter_Internalname = "LBLCOUNTRYIDFILTER";
         edtavCcountryid_Internalname = "vCCOUNTRYID";
         divCountryidfiltercontainer_Internalname = "COUNTRYIDFILTERCONTAINER";
         lblLblcityidfilter_Internalname = "LBLCITYIDFILTER";
         edtavCcityid_Internalname = "vCCITYID";
         divCityidfiltercontainer_Internalname = "CITYIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID";
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME";
         edtAmusementParkWebsite_Internalname = "AMUSEMENTPARKWEBSITE";
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO";
         edtCityId_Internalname = "CITYID";
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
         edtCityId_Jsonclick = "";
         edtAmusementParkWebsite_Jsonclick = "";
         edtAmusementParkName_Jsonclick = "";
         edtAmusementParkId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtAmusementParkName_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcityid_Jsonclick = "";
         edtavCcityid_Enabled = 1;
         edtavCcityid_Visible = 1;
         edtavCcountryid_Jsonclick = "";
         edtavCcountryid_Enabled = 1;
         edtavCcountryid_Visible = 1;
         edtavCamusementparkwebsite_Jsonclick = "";
         edtavCamusementparkwebsite_Enabled = 1;
         edtavCamusementparkwebsite_Visible = 1;
         edtavCamusementparkname_Jsonclick = "";
         edtavCamusementparkname_Enabled = 1;
         edtavCamusementparkname_Visible = 1;
         edtavCamusementparkid_Jsonclick = "";
         edtavCamusementparkid_Enabled = 1;
         edtavCamusementparkid_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Amusement Park";
         divCityidfiltercontainer_Class = "AdvancedContainerItem";
         divCountryidfiltercontainer_Class = "AdvancedContainerItem";
         divAmusementparkwebsitefiltercontainer_Class = "AdvancedContainerItem";
         divAmusementparknamefiltercontainer_Class = "AdvancedContainerItem";
         divAmusementparkidfiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAmusementParkId',fld:'vCAMUSEMENTPARKID',pic:'ZZZ9'},{av:'AV7cAmusementParkName',fld:'vCAMUSEMENTPARKNAME',pic:''},{av:'AV8cAmusementParkWebsite',fld:'vCAMUSEMENTPARKWEBSITE',pic:''},{av:'AV9cCountryId',fld:'vCCOUNTRYID',pic:'ZZZ9'},{av:'AV12cCityId',fld:'vCCITYID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16081',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLAMUSEMENTPARKIDFILTER.CLICK","{handler:'E11081',iparms:[{av:'divAmusementparkidfiltercontainer_Class',ctrl:'AMUSEMENTPARKIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLAMUSEMENTPARKIDFILTER.CLICK",",oparms:[{av:'divAmusementparkidfiltercontainer_Class',ctrl:'AMUSEMENTPARKIDFILTERCONTAINER',prop:'Class'},{av:'edtavCamusementparkid_Visible',ctrl:'vCAMUSEMENTPARKID',prop:'Visible'}]}");
         setEventMetadata("LBLAMUSEMENTPARKNAMEFILTER.CLICK","{handler:'E12081',iparms:[{av:'divAmusementparknamefiltercontainer_Class',ctrl:'AMUSEMENTPARKNAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLAMUSEMENTPARKNAMEFILTER.CLICK",",oparms:[{av:'divAmusementparknamefiltercontainer_Class',ctrl:'AMUSEMENTPARKNAMEFILTERCONTAINER',prop:'Class'},{av:'edtavCamusementparkname_Visible',ctrl:'vCAMUSEMENTPARKNAME',prop:'Visible'}]}");
         setEventMetadata("LBLAMUSEMENTPARKWEBSITEFILTER.CLICK","{handler:'E13081',iparms:[{av:'divAmusementparkwebsitefiltercontainer_Class',ctrl:'AMUSEMENTPARKWEBSITEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLAMUSEMENTPARKWEBSITEFILTER.CLICK",",oparms:[{av:'divAmusementparkwebsitefiltercontainer_Class',ctrl:'AMUSEMENTPARKWEBSITEFILTERCONTAINER',prop:'Class'},{av:'edtavCamusementparkwebsite_Visible',ctrl:'vCAMUSEMENTPARKWEBSITE',prop:'Visible'}]}");
         setEventMetadata("LBLCOUNTRYIDFILTER.CLICK","{handler:'E14081',iparms:[{av:'divCountryidfiltercontainer_Class',ctrl:'COUNTRYIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOUNTRYIDFILTER.CLICK",",oparms:[{av:'divCountryidfiltercontainer_Class',ctrl:'COUNTRYIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcountryid_Visible',ctrl:'vCCOUNTRYID',prop:'Visible'}]}");
         setEventMetadata("LBLCITYIDFILTER.CLICK","{handler:'E15081',iparms:[{av:'divCityidfiltercontainer_Class',ctrl:'CITYIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCITYIDFILTER.CLICK",",oparms:[{av:'divCityidfiltercontainer_Class',ctrl:'CITYIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcityid_Visible',ctrl:'vCCITYID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E19082',iparms:[{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV10pAmusementParkId',fld:'vPAMUSEMENTPARKID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAmusementParkId',fld:'vCAMUSEMENTPARKID',pic:'ZZZ9'},{av:'AV7cAmusementParkName',fld:'vCAMUSEMENTPARKNAME',pic:''},{av:'AV8cAmusementParkWebsite',fld:'vCAMUSEMENTPARKWEBSITE',pic:''},{av:'AV9cCountryId',fld:'vCCOUNTRYID',pic:'ZZZ9'},{av:'AV12cCityId',fld:'vCCITYID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAmusementParkId',fld:'vCAMUSEMENTPARKID',pic:'ZZZ9'},{av:'AV7cAmusementParkName',fld:'vCAMUSEMENTPARKNAME',pic:''},{av:'AV8cAmusementParkWebsite',fld:'vCAMUSEMENTPARKWEBSITE',pic:''},{av:'AV9cCountryId',fld:'vCCOUNTRYID',pic:'ZZZ9'},{av:'AV12cCityId',fld:'vCCITYID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAmusementParkId',fld:'vCAMUSEMENTPARKID',pic:'ZZZ9'},{av:'AV7cAmusementParkName',fld:'vCAMUSEMENTPARKNAME',pic:''},{av:'AV8cAmusementParkWebsite',fld:'vCAMUSEMENTPARKWEBSITE',pic:''},{av:'AV9cCountryId',fld:'vCCOUNTRYID',pic:'ZZZ9'},{av:'AV12cCityId',fld:'vCCITYID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAmusementParkId',fld:'vCAMUSEMENTPARKID',pic:'ZZZ9'},{av:'AV7cAmusementParkName',fld:'vCAMUSEMENTPARKNAME',pic:''},{av:'AV8cAmusementParkWebsite',fld:'vCAMUSEMENTPARKWEBSITE',pic:''},{av:'AV9cCountryId',fld:'vCCOUNTRYID',pic:'ZZZ9'},{av:'AV12cCityId',fld:'vCCITYID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cityid',iparms:[]");
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
         AV7cAmusementParkName = "";
         AV8cAmusementParkWebsite = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblamusementparkidfilter_Jsonclick = "";
         TempTags = "";
         lblLblamusementparknamefilter_Jsonclick = "";
         lblLblamusementparkwebsitefilter_Jsonclick = "";
         lblLblcountryidfilter_Jsonclick = "";
         lblLblcityidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A8AmusementParkName = "";
         A9AmusementParkWebsite = "";
         A11AmusementParkPhoto = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV15Linkselection_GXI = "";
         A40000AmusementParkPhoto_GXI = "";
         scmdbuf = "";
         lV7cAmusementParkName = "";
         lV8cAmusementParkWebsite = "";
         H00082_A12CountryId = new short[1] ;
         H00082_A19CityId = new short[1] ;
         H00082_n19CityId = new bool[] {false} ;
         H00082_A40000AmusementParkPhoto_GXI = new string[] {""} ;
         H00082_A9AmusementParkWebsite = new string[] {""} ;
         H00082_A8AmusementParkName = new string[] {""} ;
         H00082_A7AmusementParkId = new short[1] ;
         H00082_A11AmusementParkPhoto = new string[] {""} ;
         H00083_AGRID1_nRecordCount = new long[1] ;
         AV11ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0020__default(),
            new Object[][] {
                new Object[] {
               H00082_A12CountryId, H00082_A19CityId, H00082_n19CityId, H00082_A40000AmusementParkPhoto_GXI, H00082_A9AmusementParkWebsite, H00082_A8AmusementParkName, H00082_A7AmusementParkId, H00082_A11AmusementParkPhoto
               }
               , new Object[] {
               H00083_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10pAmusementParkId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cAmusementParkId ;
      private short AV9cCountryId ;
      private short AV12cCityId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A7AmusementParkId ;
      private short A19CityId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A12CountryId ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_64 ;
      private int nGXsfl_64_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCamusementparkid_Enabled ;
      private int edtavCamusementparkid_Visible ;
      private int edtavCamusementparkname_Visible ;
      private int edtavCamusementparkname_Enabled ;
      private int edtavCamusementparkwebsite_Visible ;
      private int edtavCamusementparkwebsite_Enabled ;
      private int edtavCcountryid_Enabled ;
      private int edtavCcountryid_Visible ;
      private int edtavCcityid_Enabled ;
      private int edtavCcityid_Visible ;
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
      private string divAmusementparkidfiltercontainer_Class ;
      private string divAmusementparknamefiltercontainer_Class ;
      private string divAmusementparkwebsitefiltercontainer_Class ;
      private string divCountryidfiltercontainer_Class ;
      private string divCityidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV7cAmusementParkName ;
      private string AV8cAmusementParkWebsite ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divAmusementparkidfiltercontainer_Internalname ;
      private string lblLblamusementparkidfilter_Internalname ;
      private string lblLblamusementparkidfilter_Jsonclick ;
      private string edtavCamusementparkid_Internalname ;
      private string TempTags ;
      private string edtavCamusementparkid_Jsonclick ;
      private string divAmusementparknamefiltercontainer_Internalname ;
      private string lblLblamusementparknamefilter_Internalname ;
      private string lblLblamusementparknamefilter_Jsonclick ;
      private string edtavCamusementparkname_Internalname ;
      private string edtavCamusementparkname_Jsonclick ;
      private string divAmusementparkwebsitefiltercontainer_Internalname ;
      private string lblLblamusementparkwebsitefilter_Internalname ;
      private string lblLblamusementparkwebsitefilter_Jsonclick ;
      private string edtavCamusementparkwebsite_Internalname ;
      private string edtavCamusementparkwebsite_Jsonclick ;
      private string divCountryidfiltercontainer_Internalname ;
      private string lblLblcountryidfilter_Internalname ;
      private string lblLblcountryidfilter_Jsonclick ;
      private string edtavCcountryid_Internalname ;
      private string edtavCcountryid_Jsonclick ;
      private string divCityidfiltercontainer_Internalname ;
      private string lblLblcityidfilter_Internalname ;
      private string lblLblcityidfilter_Jsonclick ;
      private string edtavCcityid_Internalname ;
      private string edtavCcityid_Jsonclick ;
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
      private string A8AmusementParkName ;
      private string edtAmusementParkName_Link ;
      private string A9AmusementParkWebsite ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtAmusementParkId_Internalname ;
      private string edtAmusementParkName_Internalname ;
      private string edtAmusementParkWebsite_Internalname ;
      private string edtAmusementParkPhoto_Internalname ;
      private string edtCityId_Internalname ;
      private string scmdbuf ;
      private string lV7cAmusementParkName ;
      private string lV8cAmusementParkWebsite ;
      private string AV11ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtAmusementParkId_Jsonclick ;
      private string edtAmusementParkName_Jsonclick ;
      private string edtAmusementParkWebsite_Jsonclick ;
      private string edtCityId_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool n19CityId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A11AmusementParkPhoto_IsBlob ;
      private string AV15Linkselection_GXI ;
      private string A40000AmusementParkPhoto_GXI ;
      private string AV5LinkSelection ;
      private string A11AmusementParkPhoto ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00082_A12CountryId ;
      private short[] H00082_A19CityId ;
      private bool[] H00082_n19CityId ;
      private string[] H00082_A40000AmusementParkPhoto_GXI ;
      private string[] H00082_A9AmusementParkWebsite ;
      private string[] H00082_A8AmusementParkName ;
      private short[] H00082_A7AmusementParkId ;
      private string[] H00082_A11AmusementParkPhoto ;
      private long[] H00083_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pAmusementParkId ;
      private GXWebForm Form ;
   }

   public class gx0020__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00082( IGxContext context ,
                                             string AV7cAmusementParkName ,
                                             string AV8cAmusementParkWebsite ,
                                             short AV9cCountryId ,
                                             short AV12cCityId ,
                                             string A8AmusementParkName ,
                                             string A9AmusementParkWebsite ,
                                             short A12CountryId ,
                                             short A19CityId ,
                                             short AV6cAmusementParkId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CountryId], [CityId], [AmusementParkPhoto_GXI], [AmusementParkWebsite], [AmusementParkName], [AmusementParkId], [AmusementParkPhoto]";
         sFromString = " FROM [AmusementPark]";
         sOrderString = "";
         AddWhere(sWhereString, "([AmusementParkId] >= @AV6cAmusementParkId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cAmusementParkName)) )
         {
            AddWhere(sWhereString, "([AmusementParkName] like @lV7cAmusementParkName)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cAmusementParkWebsite)) )
         {
            AddWhere(sWhereString, "([AmusementParkWebsite] like @lV8cAmusementParkWebsite)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cCountryId) )
         {
            AddWhere(sWhereString, "([CountryId] >= @AV9cCountryId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV12cCityId) )
         {
            AddWhere(sWhereString, "([CityId] >= @AV12cCityId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [AmusementParkId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00083( IGxContext context ,
                                             string AV7cAmusementParkName ,
                                             string AV8cAmusementParkWebsite ,
                                             short AV9cCountryId ,
                                             short AV12cCityId ,
                                             string A8AmusementParkName ,
                                             string A9AmusementParkWebsite ,
                                             short A12CountryId ,
                                             short A19CityId ,
                                             short AV6cAmusementParkId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [AmusementPark]";
         AddWhere(sWhereString, "([AmusementParkId] >= @AV6cAmusementParkId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cAmusementParkName)) )
         {
            AddWhere(sWhereString, "([AmusementParkName] like @lV7cAmusementParkName)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cAmusementParkWebsite)) )
         {
            AddWhere(sWhereString, "([AmusementParkWebsite] like @lV8cAmusementParkWebsite)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cCountryId) )
         {
            AddWhere(sWhereString, "([CountryId] >= @AV9cCountryId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV12cCityId) )
         {
            AddWhere(sWhereString, "([CityId] >= @AV12cCityId)");
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H00082(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H00083(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH00082;
          prmH00082 = new Object[] {
          new ParDef("@AV6cAmusementParkId",GXType.Int16,4,0) ,
          new ParDef("@lV7cAmusementParkName",GXType.NChar,20,0) ,
          new ParDef("@lV8cAmusementParkWebsite",GXType.NChar,60,0) ,
          new ParDef("@AV9cCountryId",GXType.Int16,4,0) ,
          new ParDef("@AV12cCityId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00083;
          prmH00083 = new Object[] {
          new ParDef("@AV6cAmusementParkId",GXType.Int16,4,0) ,
          new ParDef("@lV7cAmusementParkName",GXType.NChar,20,0) ,
          new ParDef("@lV8cAmusementParkWebsite",GXType.NChar,60,0) ,
          new ParDef("@AV9cCountryId",GXType.Int16,4,0) ,
          new ParDef("@AV12cCityId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00082", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00082,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00083", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00083,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 60);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
