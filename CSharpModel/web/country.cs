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
   public class country : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcountry_city") == 0 )
         {
            nRC_GXsfl_48 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_48"), "."));
            nGXsfl_48_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_48_idx"), "."));
            sGXsfl_48_idx = GetPar( "sGXsfl_48_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridcountry_city_newrow( ) ;
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
               AssignAttri("", false, "AV7CountryId", StringUtil.LTrimStr( (decimal)(AV7CountryId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCOUNTRYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CountryId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "Country", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCountryName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public country( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public country( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_CountryId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CountryId = aP1_CountryId;
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

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Country", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12CountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A12CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A12CountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A13CountryName), StringUtil.RTrim( context.localUtil.Format( A13CountryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divCitytable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlecity_Internalname, "City", "", "", lblTitlecity_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridcountry_city( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Country.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridcountry_city( )
      {
         /*  Grid Control  */
         Gridcountry_cityContainer.AddObjectProperty("GridName", "Gridcountry_city");
         Gridcountry_cityContainer.AddObjectProperty("Header", subGridcountry_city_Header);
         Gridcountry_cityContainer.AddObjectProperty("Class", "Grid");
         Gridcountry_cityContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcountry_city_Backcolorstyle), 1, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("CmpContext", "");
         Gridcountry_cityContainer.AddObjectProperty("InMasterPage", "false");
         Gridcountry_cityColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcountry_cityColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19CityId), 4, 0, ".", "")));
         Gridcountry_cityColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCityId_Enabled), 5, 0, ".", "")));
         Gridcountry_cityContainer.AddColumnProperties(Gridcountry_cityColumn);
         Gridcountry_cityColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcountry_cityColumn.AddObjectProperty("Value", StringUtil.RTrim( A20CityName));
         Gridcountry_cityColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCityName_Enabled), 5, 0, ".", "")));
         Gridcountry_cityContainer.AddColumnProperties(Gridcountry_cityColumn);
         Gridcountry_cityContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcountry_city_Selectedindex), 4, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcountry_city_Allowselection), 1, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcountry_city_Selectioncolor), 9, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcountry_city_Allowhovering), 1, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcountry_city_Hoveringcolor), 9, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcountry_city_Allowcollapsing), 1, 0, ".", "")));
         Gridcountry_cityContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcountry_city_Collapsed), 1, 0, ".", "")));
         nGXsfl_48_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount6 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_6 = 1;
               ScanStart036( ) ;
               while ( RcdFound6 != 0 )
               {
                  init_level_properties6( ) ;
                  getByPrimaryKey036( ) ;
                  AddRow036( ) ;
                  ScanNext036( ) ;
               }
               ScanEnd036( ) ;
               nBlankRcdCount6 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal036( ) ;
            standaloneModal036( ) ;
            sMode6 = Gx_mode;
            while ( nGXsfl_48_idx < nRC_GXsfl_48 )
            {
               bGXsfl_48_Refreshing = true;
               ReadRow036( ) ;
               edtCityId_Enabled = (int)(context.localUtil.CToN( cgiGet( "CITYID_"+sGXsfl_48_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtCityName_Enabled = (int)(context.localUtil.CToN( cgiGet( "CITYNAME_"+sGXsfl_48_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityName_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               if ( ( nRcdExists_6 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal036( ) ;
               }
               SendRow036( ) ;
               bGXsfl_48_Refreshing = false;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount6 = 5;
            nRcdExists_6 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart036( ) ;
               while ( RcdFound6 != 0 )
               {
                  sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_486( ) ;
                  init_level_properties6( ) ;
                  standaloneNotModal036( ) ;
                  getByPrimaryKey036( ) ;
                  standaloneModal036( ) ;
                  AddRow036( ) ;
                  ScanNext036( ) ;
               }
               ScanEnd036( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode6 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
            SubsflControlProps_486( ) ;
            InitAll036( ) ;
            init_level_properties6( ) ;
            nRcdExists_6 = 0;
            nIsMod_6 = 0;
            nRcdDeleted_6 = 0;
            nBlankRcdCount6 = (short)(nBlankRcdUsr6+nBlankRcdCount6);
            fRowAdded = 0;
            while ( nBlankRcdCount6 > 0 )
            {
               standaloneNotModal036( ) ;
               standaloneModal036( ) ;
               AddRow036( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount6 = (short)(nBlankRcdCount6-1);
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridcountry_cityContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcountry_city", Gridcountry_cityContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcountry_cityContainerData", Gridcountry_cityContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcountry_cityContainerData"+"V", Gridcountry_cityContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridcountry_cityContainerData"+"V"+"\" value='"+Gridcountry_cityContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z12CountryId = (short)(context.localUtil.CToN( cgiGet( "Z12CountryId"), ".", ","));
               Z13CountryName = cgiGet( "Z13CountryName");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_48 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_48"), ".", ","));
               AV7CountryId = (short)(context.localUtil.CToN( cgiGet( "vCOUNTRYID"), ".", ","));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A12CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ","));
               AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
               A13CountryName = cgiGet( edtCountryName_Internalname);
               AssignAttri("", false, "A13CountryName", A13CountryName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Country");
               A12CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ","));
               AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
               forbiddenHiddens.Add("CountryId", context.localUtil.Format( (decimal)(A12CountryId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A12CountryId != Z12CountryId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("country:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A12CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
                  AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COUNTRYID");
                        AnyError = 1;
                        GX_FocusControl = edtCountryId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes033( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode3 = Gx_mode;
            CONFIRM_036( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode3;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_036( )
      {
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow036( ) ;
            if ( ( nRcdExists_6 != 0 ) || ( nIsMod_6 != 0 ) )
            {
               GetKey036( ) ;
               if ( ( nRcdExists_6 == 0 ) && ( nRcdDeleted_6 == 0 ) )
               {
                  if ( RcdFound6 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate036( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable036( ) ;
                        CloseExtendedTableCursors036( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CITYID_" + sGXsfl_48_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCityId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound6 != 0 )
                  {
                     if ( nRcdDeleted_6 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey036( ) ;
                        Load036( ) ;
                        BeforeValidate036( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls036( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate036( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable036( ) ;
                              CloseExtendedTableCursors036( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_6 == 0 )
                     {
                        GXCCtl = "CITYID_" + sGXsfl_48_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCityId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19CityId), 4, 0, ".", ""))) ;
            ChangePostValue( edtCityName_Internalname, StringUtil.RTrim( A20CityName)) ;
            ChangePostValue( "ZT_"+"Z19CityId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19CityId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z20CityName_"+sGXsfl_48_idx, StringUtil.RTrim( Z20CityName)) ;
            ChangePostValue( "nRcdDeleted_6_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_6_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_6_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ".", ""))) ;
            if ( nIsMod_6 != 0 )
            {
               ChangePostValue( "CITYID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCityId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CITYNAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCityName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwcountry.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z13CountryName = T00035_A13CountryName[0];
            }
            else
            {
               Z13CountryName = A13CountryName;
            }
         }
         if ( GX_JID == -3 )
         {
            Z12CountryId = A12CountryId;
            Z13CountryName = A13CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CountryId) )
         {
            A12CountryId = AV7CountryId;
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load033( )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A12CountryId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
            A13CountryName = T00036_A13CountryName[0];
            AssignAttri("", false, "A13CountryName", A13CountryName);
            ZM033( -3) ;
         }
         pr_default.close(4);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV11Pgmname = "Country";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Country";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A13CountryName, A12CountryId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Country Name"}), 1, "COUNTRYNAME");
            AnyError = 1;
            GX_FocusControl = edtCountryName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A12CountryId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A12CountryId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM033( 3) ;
            RcdFound3 = 1;
            A12CountryId = T00035_A12CountryId[0];
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
            A13CountryName = T00035_A13CountryName[0];
            AssignAttri("", false, "A13CountryName", A13CountryName);
            Z12CountryId = A12CountryId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A12CountryId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A12CountryId[0] < A12CountryId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A12CountryId[0] > A12CountryId ) ) )
            {
               A12CountryId = T00039_A12CountryId[0];
               AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T000310 */
         pr_default.execute(8, new Object[] {A12CountryId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000310_A12CountryId[0] > A12CountryId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000310_A12CountryId[0] < A12CountryId ) ) )
            {
               A12CountryId = T000310_A12CountryId[0];
               AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCountryName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A12CountryId != Z12CountryId )
               {
                  A12CountryId = Z12CountryId;
                  AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COUNTRYID");
                  AnyError = 1;
                  GX_FocusControl = edtCountryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCountryName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtCountryName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A12CountryId != Z12CountryId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCountryName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COUNTRYID");
                     AnyError = 1;
                     GX_FocusControl = edtCountryId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCountryName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A12CountryId != Z12CountryId )
         {
            A12CountryId = Z12CountryId;
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCountryName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A12CountryId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Country"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z13CountryName, T00034_A13CountryName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z13CountryName, T00034_A13CountryName[0]) != 0 )
               {
                  GXUtil.WriteLog("country:[seudo value changed for attri]"+"CountryName");
                  GXUtil.WriteLogRaw("Old: ",Z13CountryName);
                  GXUtil.WriteLogRaw("Current: ",T00034_A13CountryName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Country"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A13CountryName});
                     A12CountryId = T000311_A12CountryId[0];
                     AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Country");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption030( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000312 */
                     pr_default.execute(10, new Object[] {A13CountryName, A12CountryId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Country");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Country"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart036( ) ;
                  while ( RcdFound6 != 0 )
                  {
                     getByPrimaryKey036( ) ;
                     Delete036( ) ;
                     ScanNext036( ) ;
                  }
                  ScanEnd036( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000313 */
                     pr_default.execute(11, new Object[] {A12CountryId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Country");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Country";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A12CountryId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Amusement Park"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel036( )
      {
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow036( ) ;
            if ( ( nRcdExists_6 != 0 ) || ( nIsMod_6 != 0 ) )
            {
               standaloneNotModal036( ) ;
               GetKey036( ) ;
               if ( ( nRcdExists_6 == 0 ) && ( nRcdDeleted_6 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert036( ) ;
               }
               else
               {
                  if ( RcdFound6 != 0 )
                  {
                     if ( ( nRcdDeleted_6 != 0 ) && ( nRcdExists_6 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete036( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update036( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_6 == 0 )
                     {
                        GXCCtl = "CITYID_" + sGXsfl_48_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCityId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19CityId), 4, 0, ".", ""))) ;
            ChangePostValue( edtCityName_Internalname, StringUtil.RTrim( A20CityName)) ;
            ChangePostValue( "ZT_"+"Z19CityId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19CityId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z20CityName_"+sGXsfl_48_idx, StringUtil.RTrim( Z20CityName)) ;
            ChangePostValue( "nRcdDeleted_6_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_6_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_6_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ".", ""))) ;
            if ( nIsMod_6 != 0 )
            {
               ChangePostValue( "CITYID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCityId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CITYNAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCityName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll036( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_6 = 0;
         nIsMod_6 = 0;
         nRcdDeleted_6 = 0;
      }

      protected void ProcessLevel033( )
      {
         /* Save parent mode. */
         sMode3 = Gx_mode;
         ProcessNestedLevel036( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("country",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("country",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000315 */
         pr_default.execute(13);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A12CountryId = T000315_A12CountryId[0];
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A12CountryId = T000315_A12CountryId[0];
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
      }

      protected void ZM036( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z20CityName = T00033_A20CityName[0];
            }
            else
            {
               Z20CityName = A20CityName;
            }
         }
         if ( GX_JID == -5 )
         {
            Z12CountryId = A12CountryId;
            Z19CityId = A19CityId;
            Z20CityName = A20CityName;
         }
      }

      protected void standaloneNotModal036( )
      {
      }

      protected void standaloneModal036( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCityId_Enabled = 0;
            AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
         else
         {
            edtCityId_Enabled = 1;
            AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
      }

      protected void Load036( )
      {
         /* Using cursor T000316 */
         pr_default.execute(14, new Object[] {A12CountryId, n19CityId, A19CityId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound6 = 1;
            A20CityName = T000316_A20CityName[0];
            ZM036( -5) ;
         }
         pr_default.close(14);
         OnLoadActions036( ) ;
      }

      protected void OnLoadActions036( )
      {
      }

      protected void CheckExtendedTable036( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal036( ) ;
      }

      protected void CloseExtendedTableCursors036( )
      {
      }

      protected void enableDisable036( )
      {
      }

      protected void GetKey036( )
      {
         /* Using cursor T000317 */
         pr_default.execute(15, new Object[] {A12CountryId, n19CityId, A19CityId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey036( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A12CountryId, n19CityId, A19CityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM036( 5) ;
            RcdFound6 = 1;
            InitializeNonKey036( ) ;
            A19CityId = T00033_A19CityId[0];
            n19CityId = T00033_n19CityId[0];
            A20CityName = T00033_A20CityName[0];
            Z12CountryId = A12CountryId;
            Z19CityId = A19CityId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load036( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey036( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal036( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes036( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency036( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A12CountryId, n19CityId, A19CityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CountryCity"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z20CityName, T00032_A20CityName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z20CityName, T00032_A20CityName[0]) != 0 )
               {
                  GXUtil.WriteLog("country:[seudo value changed for attri]"+"CityName");
                  GXUtil.WriteLogRaw("Old: ",Z20CityName);
                  GXUtil.WriteLogRaw("Current: ",T00032_A20CityName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CountryCity"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert036( )
      {
         BeforeValidate036( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable036( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM036( 0) ;
            CheckOptimisticConcurrency036( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm036( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert036( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000318 */
                     pr_default.execute(16, new Object[] {A12CountryId, n19CityId, A19CityId, A20CityName});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CountryCity");
                     if ( (pr_default.getStatus(16) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load036( ) ;
            }
            EndLevel036( ) ;
         }
         CloseExtendedTableCursors036( ) ;
      }

      protected void Update036( )
      {
         BeforeValidate036( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable036( ) ;
         }
         if ( ( nIsMod_6 != 0 ) || ( nIsDirty_6 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency036( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm036( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate036( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000319 */
                        pr_default.execute(17, new Object[] {A20CityName, A12CountryId, n19CityId, A19CityId});
                        pr_default.close(17);
                        dsDefault.SmartCacheProvider.SetUpdated("CountryCity");
                        if ( (pr_default.getStatus(17) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CountryCity"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate036( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey036( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel036( ) ;
            }
         }
         CloseExtendedTableCursors036( ) ;
      }

      protected void DeferredUpdate036( )
      {
      }

      protected void Delete036( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate036( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency036( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls036( ) ;
            AfterConfirm036( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete036( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000320 */
                  pr_default.execute(18, new Object[] {A12CountryId, n19CityId, A19CityId});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("CountryCity");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel036( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls036( )
      {
         standaloneModal036( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000321 */
            pr_default.execute(19, new Object[] {A12CountryId, n19CityId, A19CityId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Amusement Park"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel036( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart036( )
      {
         /* Scan By routine */
         /* Using cursor T000322 */
         pr_default.execute(20, new Object[] {A12CountryId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound6 = 1;
            A19CityId = T000322_A19CityId[0];
            n19CityId = T000322_n19CityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext036( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound6 = 1;
            A19CityId = T000322_A19CityId[0];
            n19CityId = T000322_n19CityId[0];
         }
      }

      protected void ScanEnd036( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm036( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert036( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate036( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete036( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete036( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate036( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes036( )
      {
         edtCityId_Enabled = 0;
         AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtCityName_Enabled = 0;
         AssignProp("", false, edtCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityName_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void send_integrity_lvl_hashes036( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void SubsflControlProps_486( )
      {
         edtCityId_Internalname = "CITYID_"+sGXsfl_48_idx;
         edtCityName_Internalname = "CITYNAME_"+sGXsfl_48_idx;
      }

      protected void SubsflControlProps_fel_486( )
      {
         edtCityId_Internalname = "CITYID_"+sGXsfl_48_fel_idx;
         edtCityName_Internalname = "CITYNAME_"+sGXsfl_48_fel_idx;
      }

      protected void AddRow036( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_486( ) ;
         SendRow036( ) ;
      }

      protected void SendRow036( )
      {
         Gridcountry_cityRow = GXWebRow.GetNew(context);
         if ( subGridcountry_city_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridcountry_city_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridcountry_city_Class, "") != 0 )
            {
               subGridcountry_city_Linesclass = subGridcountry_city_Class+"Odd";
            }
         }
         else if ( subGridcountry_city_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridcountry_city_Backstyle = 0;
            subGridcountry_city_Backcolor = subGridcountry_city_Allbackcolor;
            if ( StringUtil.StrCmp(subGridcountry_city_Class, "") != 0 )
            {
               subGridcountry_city_Linesclass = subGridcountry_city_Class+"Uniform";
            }
         }
         else if ( subGridcountry_city_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridcountry_city_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridcountry_city_Class, "") != 0 )
            {
               subGridcountry_city_Linesclass = subGridcountry_city_Class+"Odd";
            }
            subGridcountry_city_Backcolor = (int)(0x0);
         }
         else if ( subGridcountry_city_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridcountry_city_Backstyle = 1;
            if ( ((int)((nGXsfl_48_idx) % (2))) == 0 )
            {
               subGridcountry_city_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcountry_city_Class, "") != 0 )
               {
                  subGridcountry_city_Linesclass = subGridcountry_city_Class+"Even";
               }
            }
            else
            {
               subGridcountry_city_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcountry_city_Class, "") != 0 )
               {
                  subGridcountry_city_Linesclass = subGridcountry_city_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridcountry_cityRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19CityId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19CityId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCityId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)48,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridcountry_cityRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCityName_Internalname,StringUtil.RTrim( A20CityName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCityName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCityName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)48,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridcountry_cityRow);
         send_integrity_lvl_hashes036( ) ;
         GXCCtl = "Z19CityId_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19CityId), 4, 0, ".", "")));
         GXCCtl = "Z20CityName_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z20CityName));
         GXCCtl = "nRcdDeleted_6_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_6_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ".", "")));
         GXCCtl = "nIsMod_6_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_48_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vCOUNTRYID_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CITYID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCityId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CITYNAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCityName_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridcountry_cityContainer.AddRow(Gridcountry_cityRow);
      }

      protected void ReadRow036( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_486( ) ;
         edtCityId_Enabled = (int)(context.localUtil.CToN( cgiGet( "CITYID_"+sGXsfl_48_idx+"Enabled"), ".", ","));
         edtCityName_Enabled = (int)(context.localUtil.CToN( cgiGet( "CITYNAME_"+sGXsfl_48_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CITYID_" + sGXsfl_48_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCityId_Internalname;
            wbErr = true;
            A19CityId = 0;
            n19CityId = false;
         }
         else
         {
            A19CityId = (short)(context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ","));
            n19CityId = false;
         }
         A20CityName = cgiGet( edtCityName_Internalname);
         GXCCtl = "Z19CityId_" + sGXsfl_48_idx;
         Z19CityId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z20CityName_" + sGXsfl_48_idx;
         Z20CityName = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_6_" + sGXsfl_48_idx;
         nRcdDeleted_6 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_6_" + sGXsfl_48_idx;
         nRcdExists_6 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_6_" + sGXsfl_48_idx;
         nIsMod_6 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtCityId_Enabled = edtCityId_Enabled;
      }

      protected void ConfirmValues030( )
      {
         nGXsfl_48_idx = 0;
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_486( ) ;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_486( ) ;
            ChangePostValue( "Z19CityId_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z19CityId_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z19CityId_"+sGXsfl_48_idx) ;
            ChangePostValue( "Z20CityName_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z20CityName_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z20CityName_"+sGXsfl_48_idx) ;
         }
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 182860), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20236199475431", false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("country.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CountryId,4,0))}, new string[] {"Gx_mode","CountryId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Country");
         forbiddenHiddens.Add("CountryId", context.localUtil.Format( (decimal)(A12CountryId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("country:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z12CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z13CountryName", StringUtil.RTrim( Z13CountryName));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_48", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_48_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOUNTRYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CountryId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("country.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CountryId,4,0))}, new string[] {"Gx_mode","CountryId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Country" ;
      }

      public override string GetPgmdesc( )
      {
         return "Country" ;
      }

      protected void InitializeNonKey033( )
      {
         A13CountryName = "";
         AssignAttri("", false, "A13CountryName", A13CountryName);
         Z13CountryName = "";
      }

      protected void InitAll033( )
      {
         A12CountryId = 0;
         AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey036( )
      {
         A20CityName = "";
         Z20CityName = "";
      }

      protected void InitAll036( )
      {
         A19CityId = 0;
         n19CityId = false;
         InitializeNonKey036( ) ;
      }

      protected void StandaloneModalInsert036( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20236199475437", true, true);
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
         context.AddJavascriptSource("country.js", "?20236199475438", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties6( )
      {
         edtCityId_Enabled = defedtCityId_Enabled;
         AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         lblTitlecity_Internalname = "TITLECITY";
         edtCityId_Internalname = "CITYID";
         edtCityName_Internalname = "CITYNAME";
         divCitytable_Internalname = "CITYTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridcountry_city_Internalname = "GRIDCOUNTRY_CITY";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Country";
         edtCityName_Jsonclick = "";
         edtCityId_Jsonclick = "";
         subGridcountry_city_Class = "Grid";
         subGridcountry_city_Backcolorstyle = 0;
         subGridcountry_city_Allowcollapsing = 0;
         subGridcountry_city_Allowselection = 0;
         edtCityName_Enabled = 1;
         edtCityId_Enabled = 1;
         subGridcountry_city_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 1;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridcountry_city_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_486( ) ;
         while ( nGXsfl_48_idx <= nRC_GXsfl_48 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal036( ) ;
            standaloneModal036( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow036( ) ;
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_486( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridcountry_cityContainer)) ;
         /* End function gxnrGridcountry_city_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Countryname( )
      {
         /* Using cursor T000323 */
         pr_default.execute(21, new Object[] {A13CountryName, A12CountryId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Country Name"}), 1, "COUNTRYNAME");
            AnyError = 1;
            GX_FocusControl = edtCountryName_Internalname;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CountryId',fld:'vCOUNTRYID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CountryId',fld:'vCOUNTRYID',pic:'ZZZ9',hsh:true},{av:'A12CountryId',fld:'COUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[]}");
         setEventMetadata("VALID_COUNTRYNAME","{handler:'Valid_Countryname',iparms:[{av:'A13CountryName',fld:'COUNTRYNAME',pic:''},{av:'A12CountryId',fld:'COUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_COUNTRYNAME",",oparms:[]}");
         setEventMetadata("VALID_CITYID","{handler:'Valid_Cityid',iparms:[]");
         setEventMetadata("VALID_CITYID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cityname',iparms:[]");
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
         pr_default.close(1);
         pr_default.close(3);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z13CountryName = "";
         Z20CityName = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A13CountryName = "";
         lblTitlecity_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridcountry_cityContainer = new GXWebGrid( context);
         Gridcountry_cityColumn = new GXWebColumn();
         A20CityName = "";
         sMode6 = "";
         sStyleString = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00036_A12CountryId = new short[1] ;
         T00036_A13CountryName = new string[] {""} ;
         T00037_A13CountryName = new string[] {""} ;
         T00038_A12CountryId = new short[1] ;
         T00035_A12CountryId = new short[1] ;
         T00035_A13CountryName = new string[] {""} ;
         T00039_A12CountryId = new short[1] ;
         T000310_A12CountryId = new short[1] ;
         T00034_A12CountryId = new short[1] ;
         T00034_A13CountryName = new string[] {""} ;
         T000311_A12CountryId = new short[1] ;
         T000314_A7AmusementParkId = new short[1] ;
         T000315_A12CountryId = new short[1] ;
         T000316_A12CountryId = new short[1] ;
         T000316_A19CityId = new short[1] ;
         T000316_n19CityId = new bool[] {false} ;
         T000316_A20CityName = new string[] {""} ;
         T000317_A12CountryId = new short[1] ;
         T000317_A19CityId = new short[1] ;
         T000317_n19CityId = new bool[] {false} ;
         T00033_A12CountryId = new short[1] ;
         T00033_A19CityId = new short[1] ;
         T00033_n19CityId = new bool[] {false} ;
         T00033_A20CityName = new string[] {""} ;
         T00032_A12CountryId = new short[1] ;
         T00032_A19CityId = new short[1] ;
         T00032_n19CityId = new bool[] {false} ;
         T00032_A20CityName = new string[] {""} ;
         T000321_A7AmusementParkId = new short[1] ;
         T000322_A12CountryId = new short[1] ;
         T000322_A19CityId = new short[1] ;
         T000322_n19CityId = new bool[] {false} ;
         Gridcountry_cityRow = new GXWebRow();
         subGridcountry_city_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000323_A13CountryName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.country__default(),
            new Object[][] {
                new Object[] {
               T00032_A12CountryId, T00032_A19CityId, T00032_A20CityName
               }
               , new Object[] {
               T00033_A12CountryId, T00033_A19CityId, T00033_A20CityName
               }
               , new Object[] {
               T00034_A12CountryId, T00034_A13CountryName
               }
               , new Object[] {
               T00035_A12CountryId, T00035_A13CountryName
               }
               , new Object[] {
               T00036_A12CountryId, T00036_A13CountryName
               }
               , new Object[] {
               T00037_A13CountryName
               }
               , new Object[] {
               T00038_A12CountryId
               }
               , new Object[] {
               T00039_A12CountryId
               }
               , new Object[] {
               T000310_A12CountryId
               }
               , new Object[] {
               T000311_A12CountryId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000314_A7AmusementParkId
               }
               , new Object[] {
               T000315_A12CountryId
               }
               , new Object[] {
               T000316_A12CountryId, T000316_A19CityId, T000316_A20CityName
               }
               , new Object[] {
               T000317_A12CountryId, T000317_A19CityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000321_A7AmusementParkId
               }
               , new Object[] {
               T000322_A12CountryId, T000322_A19CityId
               }
               , new Object[] {
               T000323_A13CountryName
               }
            }
         );
         AV11Pgmname = "Country";
      }

      private short wcpOAV7CountryId ;
      private short Z12CountryId ;
      private short Z19CityId ;
      private short nRcdDeleted_6 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short GxWebError ;
      private short AV7CountryId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A12CountryId ;
      private short subGridcountry_city_Backcolorstyle ;
      private short A19CityId ;
      private short subGridcountry_city_Allowselection ;
      private short subGridcountry_city_Allowhovering ;
      private short subGridcountry_city_Allowcollapsing ;
      private short subGridcountry_city_Collapsed ;
      private short nBlankRcdCount6 ;
      private short RcdFound6 ;
      private short nBlankRcdUsr6 ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short nIsDirty_3 ;
      private short Gx_BScreen ;
      private short nIsDirty_6 ;
      private short subGridcountry_city_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_48 ;
      private int nGXsfl_48_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtCityId_Enabled ;
      private int edtCityName_Enabled ;
      private int subGridcountry_city_Selectedindex ;
      private int subGridcountry_city_Selectioncolor ;
      private int subGridcountry_city_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridcountry_city_Backcolor ;
      private int subGridcountry_city_Allbackcolor ;
      private int defedtCityId_Enabled ;
      private int idxLst ;
      private long GRIDCOUNTRY_CITY_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z13CountryName ;
      private string Z20CityName ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_48_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCountryName_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string A13CountryName ;
      private string edtCountryName_Jsonclick ;
      private string divCitytable_Internalname ;
      private string lblTitlecity_Internalname ;
      private string lblTitlecity_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridcountry_city_Header ;
      private string A20CityName ;
      private string sMode6 ;
      private string edtCityId_Internalname ;
      private string edtCityName_Internalname ;
      private string sStyleString ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode3 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_48_fel_idx="0001" ;
      private string subGridcountry_city_Class ;
      private string subGridcountry_city_Linesclass ;
      private string ROClassString ;
      private string edtCityId_Jsonclick ;
      private string edtCityName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridcountry_city_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_48_Refreshing=false ;
      private bool returnInSub ;
      private bool n19CityId ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridcountry_cityContainer ;
      private GXWebRow Gridcountry_cityRow ;
      private GXWebColumn Gridcountry_cityColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00036_A12CountryId ;
      private string[] T00036_A13CountryName ;
      private string[] T00037_A13CountryName ;
      private short[] T00038_A12CountryId ;
      private short[] T00035_A12CountryId ;
      private string[] T00035_A13CountryName ;
      private short[] T00039_A12CountryId ;
      private short[] T000310_A12CountryId ;
      private short[] T00034_A12CountryId ;
      private string[] T00034_A13CountryName ;
      private short[] T000311_A12CountryId ;
      private short[] T000314_A7AmusementParkId ;
      private short[] T000315_A12CountryId ;
      private short[] T000316_A12CountryId ;
      private short[] T000316_A19CityId ;
      private bool[] T000316_n19CityId ;
      private string[] T000316_A20CityName ;
      private short[] T000317_A12CountryId ;
      private short[] T000317_A19CityId ;
      private bool[] T000317_n19CityId ;
      private short[] T00033_A12CountryId ;
      private short[] T00033_A19CityId ;
      private bool[] T00033_n19CityId ;
      private string[] T00033_A20CityName ;
      private short[] T00032_A12CountryId ;
      private short[] T00032_A19CityId ;
      private bool[] T00032_n19CityId ;
      private string[] T00032_A20CityName ;
      private short[] T000321_A7AmusementParkId ;
      private short[] T000322_A12CountryId ;
      private short[] T000322_A19CityId ;
      private bool[] T000322_n19CityId ;
      private string[] T000323_A13CountryName ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class country__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@CountryName",GXType.NChar,50,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@CountryName",GXType.NChar,50,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@CountryName",GXType.NChar,50,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000317;
          prmT000317 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000318;
          prmT000318 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CityName",GXType.NChar,50,0)
          };
          Object[] prmT000319;
          prmT000319 = new Object[] {
          new ParDef("@CityName",GXType.NChar,50,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000320;
          prmT000320 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000321;
          prmT000321 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000322;
          prmT000322 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000323;
          prmT000323 = new Object[] {
          new ParDef("@CountryName",GXType.NChar,50,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [CountryId], [CityId], [CityName] FROM [CountryCity] WITH (UPDLOCK) WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [CountryId], [CityId], [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [CountryId], [CountryName] FROM [Country] WITH (UPDLOCK) WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT [CountryId], [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT TM1.[CountryId], TM1.[CountryName] FROM [Country] TM1 WHERE TM1.[CountryId] = @CountryId ORDER BY TM1.[CountryId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [CountryName] FROM [Country] WHERE ([CountryName] = @CountryName) AND (Not ( [CountryId] = @CountryId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT [CountryId] FROM [Country] WHERE [CountryId] = @CountryId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00039", "SELECT TOP 1 [CountryId] FROM [Country] WHERE ( [CountryId] > @CountryId) ORDER BY [CountryId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000310", "SELECT TOP 1 [CountryId] FROM [Country] WHERE ( [CountryId] < @CountryId) ORDER BY [CountryId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000311", "INSERT INTO [Country]([CountryName]) VALUES(@CountryName); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "UPDATE [Country] SET [CountryName]=@CountryName  WHERE [CountryId] = @CountryId", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "DELETE FROM [Country]  WHERE [CountryId] = @CountryId", GxErrorMask.GX_NOMASK,prmT000313)
             ,new CursorDef("T000314", "SELECT TOP 1 [AmusementParkId] FROM [AmusementPark] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000315", "SELECT [CountryId] FROM [Country] ORDER BY [CountryId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000316", "SELECT [CountryId], [CityId], [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId and [CityId] = @CityId ORDER BY [CountryId], [CityId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000317", "SELECT [CountryId], [CityId] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000318", "INSERT INTO [CountryCity]([CountryId], [CityId], [CityName]) VALUES(@CountryId, @CityId, @CityName)", GxErrorMask.GX_NOMASK,prmT000318)
             ,new CursorDef("T000319", "UPDATE [CountryCity] SET [CityName]=@CityName  WHERE [CountryId] = @CountryId AND [CityId] = @CityId", GxErrorMask.GX_NOMASK,prmT000319)
             ,new CursorDef("T000320", "DELETE FROM [CountryCity]  WHERE [CountryId] = @CountryId AND [CityId] = @CityId", GxErrorMask.GX_NOMASK,prmT000320)
             ,new CursorDef("T000321", "SELECT TOP 1 [AmusementParkId] FROM [AmusementPark] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000321,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000322", "SELECT [CountryId], [CityId] FROM [CountryCity] WHERE [CountryId] = @CountryId ORDER BY [CountryId], [CityId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000322,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000323", "SELECT [CountryName] FROM [Country] WHERE ([CountryName] = @CountryName) AND (Not ( [CountryId] = @CountryId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000323,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
       }
    }

 }

}
