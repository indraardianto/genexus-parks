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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wwamusementpark : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwamusementpark( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wwamusementpark( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
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
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_43 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."));
               nGXsfl_43_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."));
               sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
               AV12Update = GetPar( "Update");
               AV13Delete = GetPar( "Delete");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
               AV11AmusementParkName = GetPar( "AmusementParkName");
               AV15OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14ADVANCED_LABEL_TEMPLATE = GetPar( "ADVANCED_LABEL_TEMPLATE");
               AV12Update = GetPar( "Update");
               AV13Delete = GetPar( "Delete");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV11AmusementParkName, AV15OrderedBy, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
               GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
               GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
               GxWebStd.gx_hidden_field( context, "ORDERBYCONTAINER_Class", StringUtil.RTrim( divOrderbycontainer_Class));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
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
         PA0L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0L2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20236199443271", false, true);
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwamusementpark.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vAMUSEMENTPARKNAME", StringUtil.RTrim( AV11AmusementParkName));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "COUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORDERBYCONTAINER_Class", StringUtil.RTrim( divOrderbycontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
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
            WE0L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0L2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwamusementpark.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWAmusementPark" ;
      }

      public override string GetPgmdesc( )
      {
         return "Amusement Parks" ;
      }

      protected void WB0L0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "BodyContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 7, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110l1_client"+"'", TempTags, "", 2, "HLP_WWAmusementPark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Amusement Parks", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, 0, "HLP_WWAmusementPark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-5 col-sm-push-3 WWActionsCell", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "BtnAdd";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWAmusementPark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-sm-pull-5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAmusementparkname_Internalname, "Amusement Park Name", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAmusementparkname_Internalname, StringUtil.RTrim( AV11AmusementParkName), StringUtil.RTrim( context.localUtil.Format( AV11AmusementParkName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Park Name", edtavAmusementparkname_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavAmusementparkname_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWAmusementPark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 WWAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOrderbycontainer_Internalname, 1, 0, "px", 0, "px", divOrderbycontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorderby_Internalname, lblLblorderby_Caption, "", "", lblLblorderby_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120l1_client"+"'", "", "WWAdvancedLabel WWOrderByLabel", 7, "", 1, 1, 0, 1, "HLP_WWAmusementPark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOrderbycontainer2_Internalname, 1, 0, "px", 0, "px", "OrdersTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-6 OrdersCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrderby1_Internalname, "Park Name", "", "", lblOrderby1_Jsonclick, "'"+""+"'"+",false,"+"'"+"EORDERBY1.CLICK."+"'", "", lblOrderby1_Class, 5, "", 1, 1, 0, 0, "HLP_WWAmusementPark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-6 OrdersCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrderby2_Internalname, "Country Name", "", "", lblOrderby2_Jsonclick, "'"+""+"'"+",false,"+"'"+"EORDERBY2.CLICK."+"'", "", lblOrderby2_Class, 5, "", 1, 1, 0, 0, "HLP_WWAmusementPark.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "ContainerFluid WWAdvancedContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"43\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Park Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Park Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Park Website") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Park Address") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Park Photo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Country Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "City Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A8AmusementParkName));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtAmusementParkName_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A9AmusementParkWebsite));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A10AmusementParkAddress);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( A11AmusementParkPhoto));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A13CountryName));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCountryName_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A20CityName));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV12Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV13Delete));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0L2( )
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
            Form.Meta.addItem("description", "Amusement Parks", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0L0( ) ;
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
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
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E130L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ORDERBY1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E140L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ORDERBY2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E150L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_43_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              A7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ","));
                              A8AmusementParkName = cgiGet( edtAmusementParkName_Internalname);
                              A9AmusementParkWebsite = cgiGet( edtAmusementParkWebsite_Internalname);
                              A10AmusementParkAddress = cgiGet( edtAmusementParkAddress_Internalname);
                              A11AmusementParkPhoto = cgiGet( edtAmusementParkPhoto_Internalname);
                              AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_43_Refreshing);
                              AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
                              A13CountryName = cgiGet( edtCountryName_Internalname);
                              A20CityName = cgiGet( edtCityName_Internalname);
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E160L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E170L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E180L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Amusementparkname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vAMUSEMENTPARKNAME"), AV11AmusementParkName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void WE0L2( )
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

      protected void PA0L2( )
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavAmusementparkname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV11AmusementParkName ,
                                       short AV15OrderedBy ,
                                       string AV14ADVANCED_LABEL_TEMPLATE ,
                                       string AV12Update ,
                                       string AV13Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E170L2 ();
         GRID_nCurrentRecord = 0;
         RF0L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         RF0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV18Pgmname = "WWAmusementPark";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void RF0L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E170L2 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_432( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11AmusementParkName ,
                                                 A8AmusementParkName ,
                                                 AV15OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.SHORT
                                                 }
            });
            lV11AmusementParkName = StringUtil.PadR( StringUtil.RTrim( AV11AmusementParkName), 20, "%");
            /* Using cursor H000L2 */
            pr_default.execute(0, new Object[] {lV11AmusementParkName, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A19CityId = H000L2_A19CityId[0];
               n19CityId = H000L2_n19CityId[0];
               A12CountryId = H000L2_A12CountryId[0];
               A20CityName = H000L2_A20CityName[0];
               A13CountryName = H000L2_A13CountryName[0];
               A40000AmusementParkPhoto_GXI = H000L2_A40000AmusementParkPhoto_GXI[0];
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_43_Refreshing);
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
               A10AmusementParkAddress = H000L2_A10AmusementParkAddress[0];
               A9AmusementParkWebsite = H000L2_A9AmusementParkWebsite[0];
               A8AmusementParkName = H000L2_A8AmusementParkName[0];
               A7AmusementParkId = H000L2_A7AmusementParkId[0];
               A11AmusementParkPhoto = H000L2_A11AmusementParkPhoto[0];
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_43_Refreshing);
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
               A13CountryName = H000L2_A13CountryName[0];
               A20CityName = H000L2_A20CityName[0];
               E180L2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 43;
            WB0L0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_AMUSEMENTPARKID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11AmusementParkName ,
                                              A8AmusementParkName ,
                                              AV15OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV11AmusementParkName = StringUtil.PadR( StringUtil.RTrim( AV11AmusementParkName), 20, "%");
         /* Using cursor H000L3 */
         pr_default.execute(1, new Object[] {lV11AmusementParkName});
         GRID_nRecordCount = H000L3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11AmusementParkName, AV15OrderedBy, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11AmusementParkName, AV15OrderedBy, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11AmusementParkName, AV15OrderedBy, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11AmusementParkName, AV15OrderedBy, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11AmusementParkName, AV15OrderedBy, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV11AmusementParkName = GridState.FilterValues("Amusementparkname");
            AssignAttri("", false, "AV11AmusementParkName", AV11AmusementParkName);
         }
         if ( GridState.OrderedBy != 0 )
         {
            AV15OrderedBy = GridState.OrderedBy;
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.OrderedBy = AV15OrderedBy;
         GridState.ClearFilterValues();
         GridState.AddFilterValue("AmusementParkName", AV11AmusementParkName);
      }

      protected void before_start_formulas( )
      {
         AV18Pgmname = "WWAmusementPark";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E160L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV11AmusementParkName = cgiGet( edtavAmusementparkname_Internalname);
            AssignAttri("", false, "AV11AmusementParkName", AV11AmusementParkName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vAMUSEMENTPARKNAME"), AV11AmusementParkName) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E160L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E160L2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV18Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV18Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV12Update = "Update";
         AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
         AV13Delete = "Delete";
         AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
         AV15OrderedBy = 1;
         AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         Form.Caption = "Amusement Parks";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV14ADVANCED_LABEL_TEMPLATE", AV14ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
      }

      protected void E140L2( )
      {
         /* Orderby1_Click Routine */
         returnInSub = false;
         AV15OrderedBy = 1;
         AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         lblOrderby1_Class = "WWOrderItem"+" "+"WWOrderItemSelected";
         AssignProp("", false, lblOrderby1_Internalname, "Class", lblOrderby1_Class, true);
         lblOrderby2_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby2_Internalname, "Class", lblOrderby2_Class, true);
         gxgrGrid_refresh( subGrid_Rows, AV11AmusementParkName, AV15OrderedBy, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         /*  Sending Event outputs  */
      }

      protected void E150L2( )
      {
         /* Orderby2_Click Routine */
         returnInSub = false;
         AV15OrderedBy = 2;
         AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         lblOrderby1_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby1_Internalname, "Class", lblOrderby1_Class, true);
         lblOrderby2_Class = "WWOrderItem"+" "+"WWOrderItemSelected";
         AssignProp("", false, lblOrderby2_Internalname, "Class", lblOrderby2_Class, true);
         gxgrGrid_refresh( subGrid_Rows, AV11AmusementParkName, AV15OrderedBy, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         /*  Sending Event outputs  */
      }

      protected void E170L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
         if ( AV15OrderedBy == 1 )
         {
            lblLblorderby_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "Ordered By", "Park Name", "", "", "", "", "", "", "");
            AssignProp("", false, lblLblorderby_Internalname, "Caption", lblLblorderby_Caption, true);
         }
         else if ( AV15OrderedBy == 2 )
         {
            lblLblorderby_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "Ordered By", "Country Name", "", "", "", "", "", "", "");
            AssignProp("", false, lblLblorderby_Internalname, "Caption", lblLblorderby_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E180L2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("amusementpark.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A7AmusementParkId,4,0))}, new string[] {"Mode","AmusementParkId"}) ;
         edtavDelete_Link = formatLink("amusementpark.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A7AmusementParkId,4,0))}, new string[] {"Mode","AmusementParkId"}) ;
         edtAmusementParkName_Link = formatLink("viewamusementpark.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A7AmusementParkId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"AmusementParkId","TabCode"}) ;
         edtCountryName_Link = formatLink("viewcountry.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A12CountryId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CountryId","TabCode"}) ;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 43;
         }
         sendrow_432( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
         {
            context.DoAjaxLoad(43, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E130L2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("amusementpark.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","AmusementParkId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV18Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "AmusementPark";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20236199443321", true, true);
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
         context.AddJavascriptSource("wwamusementpark.js", "?20236199443321", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID_"+sGXsfl_43_idx;
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME_"+sGXsfl_43_idx;
         edtAmusementParkWebsite_Internalname = "AMUSEMENTPARKWEBSITE_"+sGXsfl_43_idx;
         edtAmusementParkAddress_Internalname = "AMUSEMENTPARKADDRESS_"+sGXsfl_43_idx;
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO_"+sGXsfl_43_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_43_idx;
         edtCityName_Internalname = "CITYNAME_"+sGXsfl_43_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID_"+sGXsfl_43_fel_idx;
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME_"+sGXsfl_43_fel_idx;
         edtAmusementParkWebsite_Internalname = "AMUSEMENTPARKWEBSITE_"+sGXsfl_43_fel_idx;
         edtAmusementParkAddress_Internalname = "AMUSEMENTPARKADDRESS_"+sGXsfl_43_fel_idx;
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO_"+sGXsfl_43_fel_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_43_fel_idx;
         edtCityName_Internalname = "CITYNAME_"+sGXsfl_43_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         SubsflControlProps_432( ) ;
         WB0L0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmusementParkId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkName_Internalname,StringUtil.RTrim( A8AmusementParkName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtAmusementParkName_Link,(string)"",(string)"",(string)"",(string)edtAmusementParkName_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkWebsite_Internalname,StringUtil.RTrim( A9AmusementParkWebsite),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmusementParkWebsite_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkAddress_Internalname,(string)A10AmusementParkAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A10AmusementParkAddress),(string)"_blank",(string)"",(string)"",(string)edtAmusementParkAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A11AmusementParkPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AmusementParkPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.PathToRelativeUrl( A11AmusementParkPhoto));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn WWOptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A11AmusementParkPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCountryName_Internalname,StringUtil.RTrim( A13CountryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCountryName_Link,(string)"",(string)"",(string)"",(string)edtCountryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCityName_Internalname,StringUtil.RTrim( A20CityName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCityName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0L2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtntoggle_Internalname = "BTNTOGGLE";
         lblTitletext_Internalname = "TITLETEXT";
         bttBtninsert_Internalname = "BTNINSERT";
         edtavAmusementparkname_Internalname = "vAMUSEMENTPARKNAME";
         divTabletop_Internalname = "TABLETOP";
         lblLblorderby_Internalname = "LBLORDERBY";
         lblOrderby1_Internalname = "ORDERBY1";
         lblOrderby2_Internalname = "ORDERBY2";
         divOrderbycontainer2_Internalname = "ORDERBYCONTAINER2";
         divOrderbycontainer_Internalname = "ORDERBYCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID";
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME";
         edtAmusementParkWebsite_Internalname = "AMUSEMENTPARKWEBSITE";
         edtAmusementParkAddress_Internalname = "AMUSEMENTPARKADDRESS";
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtCityName_Internalname = "CITYNAME";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavDelete_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtCityName_Jsonclick = "";
         edtCountryName_Jsonclick = "";
         edtAmusementParkAddress_Jsonclick = "";
         edtAmusementParkWebsite_Jsonclick = "";
         edtAmusementParkName_Jsonclick = "";
         edtAmusementParkId_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtCountryName_Link = "";
         edtAmusementParkName_Link = "";
         subGrid_Header = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 WWGridCell";
         lblOrderby2_Class = "WWOrderItem";
         lblOrderby1_Class = "WWOrderItem WWOrderItemSelected";
         lblLblorderby_Caption = "Ordered By";
         edtavAmusementparkname_Jsonclick = "";
         edtavAmusementparkname_Enabled = 1;
         bttBtntoggle_Class = "HideFiltersButton";
         bttBtntoggle_Tooltiptext = "Hide Filters";
         bttBtntoggle_Caption = "Hide Filters";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Amusement Parks";
         divOrderbycontainer_Class = "AdvancedContainerItem";
         divFilterscontainer_Class = "AdvancedContainerVisible";
         subGrid_Rows = 10;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11AmusementParkName',fld:'vAMUSEMENTPARKNAME',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'}]}");
         setEventMetadata("'TOGGLE'","{handler:'E110L1',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{ctrl:'BTNTOGGLE',prop:'Tooltiptext'}]}");
         setEventMetadata("LBLORDERBY.CLICK","{handler:'E120L1',iparms:[{av:'divOrderbycontainer_Class',ctrl:'ORDERBYCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLORDERBY.CLICK",",oparms:[{av:'divOrderbycontainer_Class',ctrl:'ORDERBYCONTAINER',prop:'Class'}]}");
         setEventMetadata("ORDERBY1.CLICK","{handler:'E140L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11AmusementParkName',fld:'vAMUSEMENTPARKNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''}]");
         setEventMetadata("ORDERBY1.CLICK",",oparms:[{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblOrderby1_Class',ctrl:'ORDERBY1',prop:'Class'},{av:'lblOrderby2_Class',ctrl:'ORDERBY2',prop:'Class'},{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'}]}");
         setEventMetadata("ORDERBY2.CLICK","{handler:'E150L2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11AmusementParkName',fld:'vAMUSEMENTPARKNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''}]");
         setEventMetadata("ORDERBY2.CLICK",",oparms:[{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblOrderby1_Class',ctrl:'ORDERBY1',prop:'Class'},{av:'lblOrderby2_Class',ctrl:'ORDERBY2',prop:'Class'},{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E180L2',iparms:[{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9',hsh:true},{av:'A12CountryId',fld:'COUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtAmusementParkName_Link',ctrl:'AMUSEMENTPARKNAME',prop:'Link'},{av:'edtCountryName_Link',ctrl:'COUNTRYNAME',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E130L2',iparms:[{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11AmusementParkName',fld:'vAMUSEMENTPARKNAME',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11AmusementParkName',fld:'vAMUSEMENTPARKNAME',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11AmusementParkName',fld:'vAMUSEMENTPARKNAME',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11AmusementParkName',fld:'vAMUSEMENTPARKNAME',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
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
         AV12Update = "";
         AV13Delete = "";
         AV11AmusementParkName = "";
         AV14ADVANCED_LABEL_TEMPLATE = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         lblTitletext_Jsonclick = "";
         bttBtninsert_Jsonclick = "";
         lblLblorderby_Jsonclick = "";
         lblOrderby1_Jsonclick = "";
         lblOrderby2_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A8AmusementParkName = "";
         A9AmusementParkWebsite = "";
         A10AmusementParkAddress = "";
         A11AmusementParkPhoto = "";
         A13CountryName = "";
         A20CityName = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A40000AmusementParkPhoto_GXI = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         AV18Pgmname = "";
         scmdbuf = "";
         lV11AmusementParkName = "";
         H000L2_A19CityId = new short[1] ;
         H000L2_n19CityId = new bool[] {false} ;
         H000L2_A12CountryId = new short[1] ;
         H000L2_A20CityName = new string[] {""} ;
         H000L2_A13CountryName = new string[] {""} ;
         H000L2_A40000AmusementParkPhoto_GXI = new string[] {""} ;
         H000L2_A10AmusementParkAddress = new string[] {""} ;
         H000L2_A9AmusementParkWebsite = new string[] {""} ;
         H000L2_A8AmusementParkName = new string[] {""} ;
         H000L2_A7AmusementParkId = new short[1] ;
         H000L2_A11AmusementParkPhoto = new string[] {""} ;
         H000L3_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV9TrnContext = new SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwamusementpark__default(),
            new Object[][] {
                new Object[] {
               H000L2_A19CityId, H000L2_n19CityId, H000L2_A12CountryId, H000L2_A20CityName, H000L2_A13CountryName, H000L2_A40000AmusementParkPhoto_GXI, H000L2_A10AmusementParkAddress, H000L2_A9AmusementParkWebsite, H000L2_A8AmusementParkName, H000L2_A7AmusementParkId,
               H000L2_A11AmusementParkPhoto
               }
               , new Object[] {
               H000L3_AGRID_nRecordCount
               }
            }
         );
         AV18Pgmname = "WWAmusementPark";
         /* GeneXus formulas. */
         AV18Pgmname = "WWAmusementPark";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A12CountryId ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short A7AmusementParkId ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A19CityId ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int subGrid_Rows ;
      private int edtavAmusementparkname_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GridPageCount ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string divFilterscontainer_Class ;
      private string divOrderbycontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string AV12Update ;
      private string AV13Delete ;
      private string AV11AmusementParkName ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTabletop_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string bttBtntoggle_Class ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Caption ;
      private string bttBtntoggle_Jsonclick ;
      private string bttBtntoggle_Tooltiptext ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string edtavAmusementparkname_Internalname ;
      private string edtavAmusementparkname_Jsonclick ;
      private string divFilterscontainer_Internalname ;
      private string divOrderbycontainer_Internalname ;
      private string lblLblorderby_Internalname ;
      private string lblLblorderby_Caption ;
      private string lblLblorderby_Jsonclick ;
      private string divOrderbycontainer2_Internalname ;
      private string lblOrderby1_Internalname ;
      private string lblOrderby1_Jsonclick ;
      private string lblOrderby1_Class ;
      private string lblOrderby2_Internalname ;
      private string lblOrderby2_Jsonclick ;
      private string lblOrderby2_Class ;
      private string divGridcell_Internalname ;
      private string divGridcell_Class ;
      private string divGridtable_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string A8AmusementParkName ;
      private string edtAmusementParkName_Link ;
      private string A9AmusementParkWebsite ;
      private string A13CountryName ;
      private string edtCountryName_Link ;
      private string A20CityName ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAmusementParkId_Internalname ;
      private string edtAmusementParkName_Internalname ;
      private string edtAmusementParkWebsite_Internalname ;
      private string edtAmusementParkAddress_Internalname ;
      private string edtAmusementParkPhoto_Internalname ;
      private string edtCountryName_Internalname ;
      private string edtCityName_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string AV18Pgmname ;
      private string scmdbuf ;
      private string lV11AmusementParkName ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string ROClassString ;
      private string edtAmusementParkId_Jsonclick ;
      private string edtAmusementParkName_Jsonclick ;
      private string edtAmusementParkWebsite_Jsonclick ;
      private string edtAmusementParkAddress_Jsonclick ;
      private string sImgUrl ;
      private string edtCountryName_Jsonclick ;
      private string edtCityName_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n19CityId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool A11AmusementParkPhoto_IsBlob ;
      private string A10AmusementParkAddress ;
      private string A40000AmusementParkPhoto_GXI ;
      private string A11AmusementParkPhoto ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000L2_A19CityId ;
      private bool[] H000L2_n19CityId ;
      private short[] H000L2_A12CountryId ;
      private string[] H000L2_A20CityName ;
      private string[] H000L2_A13CountryName ;
      private string[] H000L2_A40000AmusementParkPhoto_GXI ;
      private string[] H000L2_A10AmusementParkAddress ;
      private string[] H000L2_A9AmusementParkWebsite ;
      private string[] H000L2_A8AmusementParkName ;
      private short[] H000L2_A7AmusementParkId ;
      private string[] H000L2_A11AmusementParkPhoto ;
      private long[] H000L3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class wwamusementpark__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000L2( IGxContext context ,
                                             string AV11AmusementParkName ,
                                             string A8AmusementParkName ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[CityId], T1.[CountryId], T3.[CityName], T2.[CountryName], T1.[AmusementParkPhoto_GXI], T1.[AmusementParkAddress], T1.[AmusementParkWebsite], T1.[AmusementParkName], T1.[AmusementParkId], T1.[AmusementParkPhoto]";
         sFromString = " FROM (([AmusementPark] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN [CountryCity] T3 ON T3.[CountryId] = T1.[CountryId] AND T3.[CityId] = T1.[CityId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11AmusementParkName)) )
         {
            AddWhere(sWhereString, "(T1.[AmusementParkName] like @lV11AmusementParkName)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV15OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[AmusementParkName]";
         }
         else if ( AV15OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T2.[CountryName]";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[AmusementParkId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000L3( IGxContext context ,
                                             string AV11AmusementParkName ,
                                             string A8AmusementParkName ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([AmusementPark] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN [CountryCity] T3 ON T3.[CountryId] = T1.[CountryId] AND T3.[CityId] = T1.[CityId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11AmusementParkName)) )
         {
            AddWhere(sWhereString, "(T1.[AmusementParkName] like @lV11AmusementParkName)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV15OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
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
                     return conditional_H000L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
               case 1 :
                     return conditional_H000L3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
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
          Object[] prmH000L2;
          prmH000L2 = new Object[] {
          new ParDef("@lV11AmusementParkName",GXType.NChar,20,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000L3;
          prmH000L3 = new Object[] {
          new ParDef("@lV11AmusementParkName",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 50);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 60);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
