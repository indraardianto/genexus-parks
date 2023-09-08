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
   public class amusementpark : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A12CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A12CountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A12CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
            A19CityId = (short)(NumberUtil.Val( GetPar( "CityId"), "."));
            n19CityId = false;
            AssignAttri("", false, "A19CityId", StringUtil.LTrimStr( (decimal)(A19CityId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A12CountryId, A19CityId) ;
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
               AV7AmusementParkId = (short)(NumberUtil.Val( GetPar( "AmusementParkId"), "."));
               AssignAttri("", false, "AV7AmusementParkId", StringUtil.LTrimStr( (decimal)(AV7AmusementParkId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vAMUSEMENTPARKID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AmusementParkId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Amusement Park", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAmusementParkName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public amusementpark( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public amusementpark( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_AmusementParkId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AmusementParkId = aP1_AmusementParkId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Amusement Park", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_AmusementPark.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AmusementPark.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAmusementParkId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAmusementParkId_Internalname, "Park Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAmusementParkId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAmusementParkId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9") : context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmusementParkId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAmusementParkId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAmusementParkName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAmusementParkName_Internalname, "Park Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAmusementParkName_Internalname, StringUtil.RTrim( A8AmusementParkName), StringUtil.RTrim( context.localUtil.Format( A8AmusementParkName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmusementParkName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAmusementParkName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAmusementParkWebsite_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAmusementParkWebsite_Internalname, "Park Website", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAmusementParkWebsite_Internalname, StringUtil.RTrim( A9AmusementParkWebsite), StringUtil.RTrim( context.localUtil.Format( A9AmusementParkWebsite, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmusementParkWebsite_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAmusementParkWebsite_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAmusementParkAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAmusementParkAddress_Internalname, "Park Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAmusementParkAddress_Internalname, A10AmusementParkAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A10AmusementParkAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtAmusementParkAddress_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgAmusementParkPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Park Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A11AmusementParkPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AmusementParkPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.PathToRelativeUrl( A11AmusementParkPhoto));
         GxWebStd.gx_bitmap( context, imgAmusementParkPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgAmusementParkPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A11AmusementParkPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_AmusementPark.htm");
         AssignProp("", false, imgAmusementParkPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.PathToRelativeUrl( A11AmusementParkPhoto)), true);
         AssignProp("", false, imgAmusementParkPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A11AmusementParkPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12CountryId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A12CountryId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AmusementPark.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_12_Internalname, sImgUrl, imgprompt_12_Link, "", "", context.GetTheme( ), imgprompt_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AmusementPark.htm");
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
         GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A13CountryName), StringUtil.RTrim( context.localUtil.Format( A13CountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCityId_Internalname, "City Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19CityId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A19CityId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCityId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AmusementPark.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_19_Internalname, sImgUrl, imgprompt_19_Link, "", "", context.GetTheme( ), imgprompt_19_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCityName_Internalname, "City Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCityName_Internalname, StringUtil.RTrim( A20CityName), StringUtil.RTrim( context.localUtil.Format( A20CityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCityName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_AmusementPark.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AmusementPark.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( "Z7AmusementParkId"), ".", ","));
               Z8AmusementParkName = cgiGet( "Z8AmusementParkName");
               Z9AmusementParkWebsite = cgiGet( "Z9AmusementParkWebsite");
               Z10AmusementParkAddress = cgiGet( "Z10AmusementParkAddress");
               Z12CountryId = (short)(context.localUtil.CToN( cgiGet( "Z12CountryId"), ".", ","));
               Z19CityId = (short)(context.localUtil.CToN( cgiGet( "Z19CityId"), ".", ","));
               n19CityId = ((0==A19CityId) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N12CountryId = (short)(context.localUtil.CToN( cgiGet( "N12CountryId"), ".", ","));
               N19CityId = (short)(context.localUtil.CToN( cgiGet( "N19CityId"), ".", ","));
               n19CityId = ((0==A19CityId) ? true : false);
               AV7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( "vAMUSEMENTPARKID"), ".", ","));
               AV11Insert_CountryId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_COUNTRYID"), ".", ","));
               AV12Insert_CityId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CITYID"), ".", ","));
               A40000AmusementParkPhoto_GXI = cgiGet( "AMUSEMENTPARKPHOTO_GXI");
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ","));
               n7AmusementParkId = false;
               AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
               A8AmusementParkName = cgiGet( edtAmusementParkName_Internalname);
               AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
               A9AmusementParkWebsite = cgiGet( edtAmusementParkWebsite_Internalname);
               AssignAttri("", false, "A9AmusementParkWebsite", A9AmusementParkWebsite);
               A10AmusementParkAddress = cgiGet( edtAmusementParkAddress_Internalname);
               AssignAttri("", false, "A10AmusementParkAddress", A10AmusementParkAddress);
               A11AmusementParkPhoto = cgiGet( imgAmusementParkPhoto_Internalname);
               AssignAttri("", false, "A11AmusementParkPhoto", A11AmusementParkPhoto);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COUNTRYID");
                  AnyError = 1;
                  GX_FocusControl = edtCountryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A12CountryId = 0;
                  AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
               }
               else
               {
                  A12CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ","));
                  AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
               }
               A13CountryName = cgiGet( edtCountryName_Internalname);
               AssignAttri("", false, "A13CountryName", A13CountryName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CITYID");
                  AnyError = 1;
                  GX_FocusControl = edtCityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A19CityId = 0;
                  n19CityId = false;
                  AssignAttri("", false, "A19CityId", StringUtil.LTrimStr( (decimal)(A19CityId), 4, 0));
               }
               else
               {
                  A19CityId = (short)(context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ","));
                  n19CityId = false;
                  AssignAttri("", false, "A19CityId", StringUtil.LTrimStr( (decimal)(A19CityId), 4, 0));
               }
               n19CityId = ((0==A19CityId) ? true : false);
               A20CityName = cgiGet( edtCityName_Internalname);
               AssignAttri("", false, "A20CityName", A20CityName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgAmusementParkPhoto_Internalname, ref  A11AmusementParkPhoto, ref  A40000AmusementParkPhoto_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"AmusementPark");
               A7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ","));
               n7AmusementParkId = false;
               AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
               forbiddenHiddens.Add("AmusementParkId", context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A7AmusementParkId != Z7AmusementParkId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("amusementpark:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A7AmusementParkId = (short)(NumberUtil.Val( GetPar( "AmusementParkId"), "."));
                  n7AmusementParkId = false;
                  AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AMUSEMENTPARKID");
                        AnyError = 1;
                        GX_FocusControl = edtAmusementParkId_Internalname;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_CountryId = 0;
         AssignAttri("", false, "AV11Insert_CountryId", StringUtil.LTrimStr( (decimal)(AV11Insert_CountryId), 4, 0));
         AV12Insert_CityId = 0;
         AssignAttri("", false, "AV12Insert_CityId", StringUtil.LTrimStr( (decimal)(AV12Insert_CityId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CountryId") == 0 )
               {
                  AV11Insert_CountryId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_CountryId", StringUtil.LTrimStr( (decimal)(AV11Insert_CountryId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CityId") == 0 )
               {
                  AV12Insert_CityId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_CityId", StringUtil.LTrimStr( (decimal)(AV12Insert_CityId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwamusementpark.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         pr_default.close(3);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z8AmusementParkName = T00023_A8AmusementParkName[0];
               Z9AmusementParkWebsite = T00023_A9AmusementParkWebsite[0];
               Z10AmusementParkAddress = T00023_A10AmusementParkAddress[0];
               Z12CountryId = T00023_A12CountryId[0];
               Z19CityId = T00023_A19CityId[0];
            }
            else
            {
               Z8AmusementParkName = A8AmusementParkName;
               Z9AmusementParkWebsite = A9AmusementParkWebsite;
               Z10AmusementParkAddress = A10AmusementParkAddress;
               Z12CountryId = A12CountryId;
               Z19CityId = A19CityId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z7AmusementParkId = A7AmusementParkId;
            Z8AmusementParkName = A8AmusementParkName;
            Z9AmusementParkWebsite = A9AmusementParkWebsite;
            Z10AmusementParkAddress = A10AmusementParkAddress;
            Z11AmusementParkPhoto = A11AmusementParkPhoto;
            Z40000AmusementParkPhoto_GXI = A40000AmusementParkPhoto_GXI;
            Z12CountryId = A12CountryId;
            Z19CityId = A19CityId;
            Z13CountryName = A13CountryName;
            Z20CityName = A20CityName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAmusementParkId_Enabled = 0;
         AssignProp("", false, edtAmusementParkId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkId_Enabled), 5, 0), true);
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COUNTRYID"+"'), id:'"+"COUNTRYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_19_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0061.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COUNTRYID"+"'), id:'"+"COUNTRYID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"CITYID"+"'), id:'"+"CITYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtAmusementParkId_Enabled = 0;
         AssignProp("", false, edtAmusementParkId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AmusementParkId) )
         {
            A7AmusementParkId = AV7AmusementParkId;
            n7AmusementParkId = false;
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CountryId) )
         {
            edtCountryId_Enabled = 0;
            AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         }
         else
         {
            edtCountryId_Enabled = 1;
            AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CityId) )
         {
            edtCityId_Enabled = 0;
            AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), true);
         }
         else
         {
            edtCityId_Enabled = 1;
            AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CityId) )
         {
            A19CityId = AV12Insert_CityId;
            n19CityId = false;
            AssignAttri("", false, "A19CityId", StringUtil.LTrimStr( (decimal)(A19CityId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CountryId) )
         {
            A12CountryId = AV11Insert_CountryId;
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV14Pgmname = "AmusementPark";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A12CountryId});
            A13CountryName = T00024_A13CountryName[0];
            AssignAttri("", false, "A13CountryName", A13CountryName);
            pr_default.close(2);
            /* Using cursor T00025 */
            pr_default.execute(3, new Object[] {A12CountryId, n19CityId, A19CityId});
            A20CityName = T00025_A20CityName[0];
            AssignAttri("", false, "A20CityName", A20CityName);
            pr_default.close(3);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound2 = 1;
            A8AmusementParkName = T00026_A8AmusementParkName[0];
            AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
            A9AmusementParkWebsite = T00026_A9AmusementParkWebsite[0];
            AssignAttri("", false, "A9AmusementParkWebsite", A9AmusementParkWebsite);
            A10AmusementParkAddress = T00026_A10AmusementParkAddress[0];
            AssignAttri("", false, "A10AmusementParkAddress", A10AmusementParkAddress);
            A40000AmusementParkPhoto_GXI = T00026_A40000AmusementParkPhoto_GXI[0];
            AssignProp("", false, imgAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), true);
            AssignProp("", false, imgAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
            A13CountryName = T00026_A13CountryName[0];
            AssignAttri("", false, "A13CountryName", A13CountryName);
            A20CityName = T00026_A20CityName[0];
            AssignAttri("", false, "A20CityName", A20CityName);
            A12CountryId = T00026_A12CountryId[0];
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
            A19CityId = T00026_A19CityId[0];
            n19CityId = T00026_n19CityId[0];
            AssignAttri("", false, "A19CityId", StringUtil.LTrimStr( (decimal)(A19CityId), 4, 0));
            A11AmusementParkPhoto = T00026_A11AmusementParkPhoto[0];
            AssignAttri("", false, "A11AmusementParkPhoto", A11AmusementParkPhoto);
            AssignProp("", false, imgAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), true);
            AssignProp("", false, imgAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
            ZM022( -11) ;
         }
         pr_default.close(4);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV14Pgmname = "AmusementPark";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "AmusementPark";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A8AmusementParkName, n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Amusement Park Name"}), 1, "AMUSEMENTPARKNAME");
            AnyError = 1;
            GX_FocusControl = edtAmusementParkName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A12CountryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13CountryName = T00024_A13CountryName[0];
         AssignAttri("", false, "A13CountryName", A13CountryName);
         pr_default.close(2);
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A12CountryId, n19CityId, A19CityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A12CountryId) || (0==A19CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A20CityName = T00025_A20CityName[0];
         AssignAttri("", false, "A20CityName", A20CityName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( short A12CountryId )
      {
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A12CountryId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A13CountryName = T00028_A13CountryName[0];
         AssignAttri("", false, "A13CountryName", A13CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A13CountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_14( short A12CountryId ,
                                short A19CityId )
      {
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A12CountryId, n19CityId, A19CityId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A12CountryId) || (0==A19CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A20CityName = T00029_A20CityName[0];
         AssignAttri("", false, "A20CityName", A20CityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A20CityName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 11) ;
            RcdFound2 = 1;
            A7AmusementParkId = T00023_A7AmusementParkId[0];
            n7AmusementParkId = T00023_n7AmusementParkId[0];
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            A8AmusementParkName = T00023_A8AmusementParkName[0];
            AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
            A9AmusementParkWebsite = T00023_A9AmusementParkWebsite[0];
            AssignAttri("", false, "A9AmusementParkWebsite", A9AmusementParkWebsite);
            A10AmusementParkAddress = T00023_A10AmusementParkAddress[0];
            AssignAttri("", false, "A10AmusementParkAddress", A10AmusementParkAddress);
            A40000AmusementParkPhoto_GXI = T00023_A40000AmusementParkPhoto_GXI[0];
            AssignProp("", false, imgAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), true);
            AssignProp("", false, imgAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
            A12CountryId = T00023_A12CountryId[0];
            AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
            A19CityId = T00023_A19CityId[0];
            n19CityId = T00023_n19CityId[0];
            AssignAttri("", false, "A19CityId", StringUtil.LTrimStr( (decimal)(A19CityId), 4, 0));
            A11AmusementParkPhoto = T00023_A11AmusementParkPhoto[0];
            AssignAttri("", false, "A11AmusementParkPhoto", A11AmusementParkPhoto);
            AssignProp("", false, imgAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), true);
            AssignProp("", false, imgAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
            Z7AmusementParkId = A7AmusementParkId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000211 */
         pr_default.execute(9, new Object[] {n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000211_A7AmusementParkId[0] < A7AmusementParkId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000211_A7AmusementParkId[0] > A7AmusementParkId ) ) )
            {
               A7AmusementParkId = T000211_A7AmusementParkId[0];
               n7AmusementParkId = T000211_n7AmusementParkId[0];
               AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000212 */
         pr_default.execute(10, new Object[] {n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000212_A7AmusementParkId[0] > A7AmusementParkId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000212_A7AmusementParkId[0] < A7AmusementParkId ) ) )
            {
               A7AmusementParkId = T000212_A7AmusementParkId[0];
               n7AmusementParkId = T000212_n7AmusementParkId[0];
               AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAmusementParkName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A7AmusementParkId != Z7AmusementParkId )
               {
                  A7AmusementParkId = Z7AmusementParkId;
                  n7AmusementParkId = false;
                  AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AMUSEMENTPARKID");
                  AnyError = 1;
                  GX_FocusControl = edtAmusementParkId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAmusementParkName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtAmusementParkName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A7AmusementParkId != Z7AmusementParkId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAmusementParkName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AMUSEMENTPARKID");
                     AnyError = 1;
                     GX_FocusControl = edtAmusementParkId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAmusementParkName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A7AmusementParkId != Z7AmusementParkId )
         {
            A7AmusementParkId = Z7AmusementParkId;
            n7AmusementParkId = false;
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AMUSEMENTPARKID");
            AnyError = 1;
            GX_FocusControl = edtAmusementParkId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAmusementParkName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {n7AmusementParkId, A7AmusementParkId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AmusementPark"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8AmusementParkName, T00022_A8AmusementParkName[0]) != 0 ) || ( StringUtil.StrCmp(Z9AmusementParkWebsite, T00022_A9AmusementParkWebsite[0]) != 0 ) || ( StringUtil.StrCmp(Z10AmusementParkAddress, T00022_A10AmusementParkAddress[0]) != 0 ) || ( Z12CountryId != T00022_A12CountryId[0] ) || ( Z19CityId != T00022_A19CityId[0] ) )
            {
               if ( StringUtil.StrCmp(Z8AmusementParkName, T00022_A8AmusementParkName[0]) != 0 )
               {
                  GXUtil.WriteLog("amusementpark:[seudo value changed for attri]"+"AmusementParkName");
                  GXUtil.WriteLogRaw("Old: ",Z8AmusementParkName);
                  GXUtil.WriteLogRaw("Current: ",T00022_A8AmusementParkName[0]);
               }
               if ( StringUtil.StrCmp(Z9AmusementParkWebsite, T00022_A9AmusementParkWebsite[0]) != 0 )
               {
                  GXUtil.WriteLog("amusementpark:[seudo value changed for attri]"+"AmusementParkWebsite");
                  GXUtil.WriteLogRaw("Old: ",Z9AmusementParkWebsite);
                  GXUtil.WriteLogRaw("Current: ",T00022_A9AmusementParkWebsite[0]);
               }
               if ( StringUtil.StrCmp(Z10AmusementParkAddress, T00022_A10AmusementParkAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("amusementpark:[seudo value changed for attri]"+"AmusementParkAddress");
                  GXUtil.WriteLogRaw("Old: ",Z10AmusementParkAddress);
                  GXUtil.WriteLogRaw("Current: ",T00022_A10AmusementParkAddress[0]);
               }
               if ( Z12CountryId != T00022_A12CountryId[0] )
               {
                  GXUtil.WriteLog("amusementpark:[seudo value changed for attri]"+"CountryId");
                  GXUtil.WriteLogRaw("Old: ",Z12CountryId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A12CountryId[0]);
               }
               if ( Z19CityId != T00022_A19CityId[0] )
               {
                  GXUtil.WriteLog("amusementpark:[seudo value changed for attri]"+"CityId");
                  GXUtil.WriteLogRaw("Old: ",Z19CityId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A19CityId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AmusementPark"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000213 */
                     pr_default.execute(11, new Object[] {A8AmusementParkName, A9AmusementParkWebsite, A10AmusementParkAddress, A11AmusementParkPhoto, A40000AmusementParkPhoto_GXI, A12CountryId, n19CityId, A19CityId});
                     A7AmusementParkId = T000213_A7AmusementParkId[0];
                     n7AmusementParkId = T000213_n7AmusementParkId[0];
                     AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("AmusementPark");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000214 */
                     pr_default.execute(12, new Object[] {A8AmusementParkName, A9AmusementParkWebsite, A10AmusementParkAddress, A12CountryId, n19CityId, A19CityId, n7AmusementParkId, A7AmusementParkId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("AmusementPark");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AmusementPark"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000215 */
            pr_default.execute(13, new Object[] {A11AmusementParkPhoto, A40000AmusementParkPhoto_GXI, n7AmusementParkId, A7AmusementParkId});
            pr_default.close(13);
            dsDefault.SmartCacheProvider.SetUpdated("AmusementPark");
         }
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000216 */
                  pr_default.execute(14, new Object[] {n7AmusementParkId, A7AmusementParkId});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("AmusementPark");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "AmusementPark";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000217 */
            pr_default.execute(15, new Object[] {A12CountryId});
            A13CountryName = T000217_A13CountryName[0];
            AssignAttri("", false, "A13CountryName", A13CountryName);
            pr_default.close(15);
            /* Using cursor T000218 */
            pr_default.execute(16, new Object[] {A12CountryId, n19CityId, A19CityId});
            A20CityName = T000218_A20CityName[0];
            AssignAttri("", false, "A20CityName", A20CityName);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000219 */
            pr_default.execute(17, new Object[] {n7AmusementParkId, A7AmusementParkId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Game"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000220 */
            pr_default.execute(18, new Object[] {n7AmusementParkId, A7AmusementParkId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Employee"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("amusementpark",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("amusementpark",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000221 */
         pr_default.execute(19);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound2 = 1;
            A7AmusementParkId = T000221_A7AmusementParkId[0];
            n7AmusementParkId = T000221_n7AmusementParkId[0];
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound2 = 1;
            A7AmusementParkId = T000221_A7AmusementParkId[0];
            n7AmusementParkId = T000221_n7AmusementParkId[0];
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtAmusementParkId_Enabled = 0;
         AssignProp("", false, edtAmusementParkId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkId_Enabled), 5, 0), true);
         edtAmusementParkName_Enabled = 0;
         AssignProp("", false, edtAmusementParkName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkName_Enabled), 5, 0), true);
         edtAmusementParkWebsite_Enabled = 0;
         AssignProp("", false, edtAmusementParkWebsite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkWebsite_Enabled), 5, 0), true);
         edtAmusementParkAddress_Enabled = 0;
         AssignProp("", false, edtAmusementParkAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkAddress_Enabled), 5, 0), true);
         imgAmusementParkPhoto_Enabled = 0;
         AssignProp("", false, imgAmusementParkPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgAmusementParkPhoto_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
         edtCityId_Enabled = 0;
         AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), true);
         edtCityName_Enabled = 0;
         AssignProp("", false, edtCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
      {
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
         context.AddJavascriptSource("gxcfg.js", "?2023619944377", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("amusementpark.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AmusementParkId,4,0))}, new string[] {"Gx_mode","AmusementParkId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"AmusementPark");
         forbiddenHiddens.Add("AmusementParkId", context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("amusementpark:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7AmusementParkId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AmusementParkId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8AmusementParkName", StringUtil.RTrim( Z8AmusementParkName));
         GxWebStd.gx_hidden_field( context, "Z9AmusementParkWebsite", StringUtil.RTrim( Z9AmusementParkWebsite));
         GxWebStd.gx_hidden_field( context, "Z10AmusementParkAddress", Z10AmusementParkAddress);
         GxWebStd.gx_hidden_field( context, "Z12CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z19CityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19CityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N12CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N19CityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19CityId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vAMUSEMENTPARKID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AmusementParkId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAMUSEMENTPARKID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AmusementParkId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_CityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKPHOTO_GXI", A40000AmusementParkPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GXCCtlgxBlob = "AMUSEMENTPARKPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A11AmusementParkPhoto);
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
         return formatLink("amusementpark.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AmusementParkId,4,0))}, new string[] {"Gx_mode","AmusementParkId"})  ;
      }

      public override string GetPgmname( )
      {
         return "AmusementPark" ;
      }

      public override string GetPgmdesc( )
      {
         return "Amusement Park" ;
      }

      protected void InitializeNonKey022( )
      {
         A12CountryId = 0;
         AssignAttri("", false, "A12CountryId", StringUtil.LTrimStr( (decimal)(A12CountryId), 4, 0));
         A19CityId = 0;
         n19CityId = false;
         AssignAttri("", false, "A19CityId", StringUtil.LTrimStr( (decimal)(A19CityId), 4, 0));
         n19CityId = ((0==A19CityId) ? true : false);
         A8AmusementParkName = "";
         AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
         A9AmusementParkWebsite = "";
         AssignAttri("", false, "A9AmusementParkWebsite", A9AmusementParkWebsite);
         A10AmusementParkAddress = "";
         AssignAttri("", false, "A10AmusementParkAddress", A10AmusementParkAddress);
         A11AmusementParkPhoto = "";
         AssignAttri("", false, "A11AmusementParkPhoto", A11AmusementParkPhoto);
         AssignProp("", false, imgAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), true);
         AssignProp("", false, imgAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
         A40000AmusementParkPhoto_GXI = "";
         AssignProp("", false, imgAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), true);
         AssignProp("", false, imgAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
         A13CountryName = "";
         AssignAttri("", false, "A13CountryName", A13CountryName);
         A20CityName = "";
         AssignAttri("", false, "A20CityName", A20CityName);
         Z8AmusementParkName = "";
         Z9AmusementParkWebsite = "";
         Z10AmusementParkAddress = "";
         Z12CountryId = 0;
         Z19CityId = 0;
      }

      protected void InitAll022( )
      {
         A7AmusementParkId = 0;
         n7AmusementParkId = false;
         AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20236199443714", true, true);
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
         context.AddJavascriptSource("amusementpark.js", "?20236199443715", false, true);
         /* End function include_jscripts */
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
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID";
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME";
         edtAmusementParkWebsite_Internalname = "AMUSEMENTPARKWEBSITE";
         edtAmusementParkAddress_Internalname = "AMUSEMENTPARKADDRESS";
         imgAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtCityId_Internalname = "CITYID";
         edtCityName_Internalname = "CITYNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_12_Internalname = "PROMPT_12";
         imgprompt_19_Internalname = "PROMPT_19";
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
         Form.Caption = "Amusement Park";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCityName_Jsonclick = "";
         edtCityName_Enabled = 0;
         imgprompt_19_Visible = 1;
         imgprompt_19_Link = "";
         edtCityId_Jsonclick = "";
         edtCityId_Enabled = 1;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         imgprompt_12_Visible = 1;
         imgprompt_12_Link = "";
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 1;
         imgAmusementParkPhoto_Enabled = 1;
         edtAmusementParkAddress_Enabled = 1;
         edtAmusementParkWebsite_Jsonclick = "";
         edtAmusementParkWebsite_Enabled = 1;
         edtAmusementParkName_Jsonclick = "";
         edtAmusementParkName_Enabled = 1;
         edtAmusementParkId_Jsonclick = "";
         edtAmusementParkId_Enabled = 0;
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

      public void Valid_Amusementparkname( )
      {
         n7AmusementParkId = false;
         /* Using cursor T000222 */
         pr_default.execute(20, new Object[] {A8AmusementParkName, n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Amusement Park Name"}), 1, "AMUSEMENTPARKNAME");
            AnyError = 1;
            GX_FocusControl = edtAmusementParkName_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Countryid( )
      {
         /* Using cursor T000217 */
         pr_default.execute(15, new Object[] {A12CountryId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
         }
         A13CountryName = T000217_A13CountryName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13CountryName", StringUtil.RTrim( A13CountryName));
      }

      public void Valid_Cityid( )
      {
         n19CityId = false;
         /* Using cursor T000218 */
         pr_default.execute(16, new Object[] {A12CountryId, n19CityId, A19CityId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A12CountryId) || (0==A19CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
            }
         }
         A20CityName = T000218_A20CityName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A20CityName", StringUtil.RTrim( A20CityName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7AmusementParkId',fld:'vAMUSEMENTPARKID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7AmusementParkId',fld:'vAMUSEMENTPARKID',pic:'ZZZ9',hsh:true},{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_AMUSEMENTPARKID","{handler:'Valid_Amusementparkid',iparms:[]");
         setEventMetadata("VALID_AMUSEMENTPARKID",",oparms:[]}");
         setEventMetadata("VALID_AMUSEMENTPARKNAME","{handler:'Valid_Amusementparkname',iparms:[{av:'A8AmusementParkName',fld:'AMUSEMENTPARKNAME',pic:''},{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_AMUSEMENTPARKNAME",",oparms:[]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[{av:'A12CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A13CountryName',fld:'COUNTRYNAME',pic:''}]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[{av:'A13CountryName',fld:'COUNTRYNAME',pic:''}]}");
         setEventMetadata("VALID_CITYID","{handler:'Valid_Cityid',iparms:[{av:'A12CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A19CityId',fld:'CITYID',pic:'ZZZ9'},{av:'A20CityName',fld:'CITYNAME',pic:''}]");
         setEventMetadata("VALID_CITYID",",oparms:[{av:'A20CityName',fld:'CITYNAME',pic:''}]}");
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
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z8AmusementParkName = "";
         Z9AmusementParkWebsite = "";
         Z10AmusementParkAddress = "";
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
         A8AmusementParkName = "";
         A9AmusementParkWebsite = "";
         A10AmusementParkAddress = "";
         A11AmusementParkPhoto = "";
         A40000AmusementParkPhoto_GXI = "";
         sImgUrl = "";
         A13CountryName = "";
         A20CityName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z11AmusementParkPhoto = "";
         Z40000AmusementParkPhoto_GXI = "";
         Z13CountryName = "";
         Z20CityName = "";
         T00024_A13CountryName = new string[] {""} ;
         T00025_A20CityName = new string[] {""} ;
         T00026_A7AmusementParkId = new short[1] ;
         T00026_n7AmusementParkId = new bool[] {false} ;
         T00026_A8AmusementParkName = new string[] {""} ;
         T00026_A9AmusementParkWebsite = new string[] {""} ;
         T00026_A10AmusementParkAddress = new string[] {""} ;
         T00026_A40000AmusementParkPhoto_GXI = new string[] {""} ;
         T00026_A13CountryName = new string[] {""} ;
         T00026_A20CityName = new string[] {""} ;
         T00026_A12CountryId = new short[1] ;
         T00026_A19CityId = new short[1] ;
         T00026_n19CityId = new bool[] {false} ;
         T00026_A11AmusementParkPhoto = new string[] {""} ;
         T00027_A8AmusementParkName = new string[] {""} ;
         T00028_A13CountryName = new string[] {""} ;
         T00029_A20CityName = new string[] {""} ;
         T000210_A7AmusementParkId = new short[1] ;
         T000210_n7AmusementParkId = new bool[] {false} ;
         T00023_A7AmusementParkId = new short[1] ;
         T00023_n7AmusementParkId = new bool[] {false} ;
         T00023_A8AmusementParkName = new string[] {""} ;
         T00023_A9AmusementParkWebsite = new string[] {""} ;
         T00023_A10AmusementParkAddress = new string[] {""} ;
         T00023_A40000AmusementParkPhoto_GXI = new string[] {""} ;
         T00023_A12CountryId = new short[1] ;
         T00023_A19CityId = new short[1] ;
         T00023_n19CityId = new bool[] {false} ;
         T00023_A11AmusementParkPhoto = new string[] {""} ;
         T000211_A7AmusementParkId = new short[1] ;
         T000211_n7AmusementParkId = new bool[] {false} ;
         T000212_A7AmusementParkId = new short[1] ;
         T000212_n7AmusementParkId = new bool[] {false} ;
         T00022_A7AmusementParkId = new short[1] ;
         T00022_n7AmusementParkId = new bool[] {false} ;
         T00022_A8AmusementParkName = new string[] {""} ;
         T00022_A9AmusementParkWebsite = new string[] {""} ;
         T00022_A10AmusementParkAddress = new string[] {""} ;
         T00022_A40000AmusementParkPhoto_GXI = new string[] {""} ;
         T00022_A12CountryId = new short[1] ;
         T00022_A19CityId = new short[1] ;
         T00022_n19CityId = new bool[] {false} ;
         T00022_A11AmusementParkPhoto = new string[] {""} ;
         T000213_A7AmusementParkId = new short[1] ;
         T000213_n7AmusementParkId = new bool[] {false} ;
         T000217_A13CountryName = new string[] {""} ;
         T000218_A20CityName = new string[] {""} ;
         T000219_A16GameId = new short[1] ;
         T000220_A1EmployeeId = new short[1] ;
         T000221_A7AmusementParkId = new short[1] ;
         T000221_n7AmusementParkId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         T000222_A8AmusementParkName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amusementpark__default(),
            new Object[][] {
                new Object[] {
               T00022_A7AmusementParkId, T00022_A8AmusementParkName, T00022_A9AmusementParkWebsite, T00022_A10AmusementParkAddress, T00022_A40000AmusementParkPhoto_GXI, T00022_A12CountryId, T00022_A19CityId, T00022_n19CityId, T00022_A11AmusementParkPhoto
               }
               , new Object[] {
               T00023_A7AmusementParkId, T00023_A8AmusementParkName, T00023_A9AmusementParkWebsite, T00023_A10AmusementParkAddress, T00023_A40000AmusementParkPhoto_GXI, T00023_A12CountryId, T00023_A19CityId, T00023_n19CityId, T00023_A11AmusementParkPhoto
               }
               , new Object[] {
               T00024_A13CountryName
               }
               , new Object[] {
               T00025_A20CityName
               }
               , new Object[] {
               T00026_A7AmusementParkId, T00026_A8AmusementParkName, T00026_A9AmusementParkWebsite, T00026_A10AmusementParkAddress, T00026_A40000AmusementParkPhoto_GXI, T00026_A13CountryName, T00026_A20CityName, T00026_A12CountryId, T00026_A19CityId, T00026_n19CityId,
               T00026_A11AmusementParkPhoto
               }
               , new Object[] {
               T00027_A8AmusementParkName
               }
               , new Object[] {
               T00028_A13CountryName
               }
               , new Object[] {
               T00029_A20CityName
               }
               , new Object[] {
               T000210_A7AmusementParkId
               }
               , new Object[] {
               T000211_A7AmusementParkId
               }
               , new Object[] {
               T000212_A7AmusementParkId
               }
               , new Object[] {
               T000213_A7AmusementParkId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000217_A13CountryName
               }
               , new Object[] {
               T000218_A20CityName
               }
               , new Object[] {
               T000219_A16GameId
               }
               , new Object[] {
               T000220_A1EmployeeId
               }
               , new Object[] {
               T000221_A7AmusementParkId
               }
               , new Object[] {
               T000222_A8AmusementParkName
               }
            }
         );
         AV14Pgmname = "AmusementPark";
      }

      private short wcpOAV7AmusementParkId ;
      private short Z7AmusementParkId ;
      private short Z12CountryId ;
      private short Z19CityId ;
      private short N12CountryId ;
      private short N19CityId ;
      private short GxWebError ;
      private short A12CountryId ;
      private short A19CityId ;
      private short AV7AmusementParkId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A7AmusementParkId ;
      private short AV11Insert_CountryId ;
      private short AV12Insert_CityId ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_2 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAmusementParkId_Enabled ;
      private int edtAmusementParkName_Enabled ;
      private int edtAmusementParkWebsite_Enabled ;
      private int edtAmusementParkAddress_Enabled ;
      private int imgAmusementParkPhoto_Enabled ;
      private int edtCountryId_Enabled ;
      private int imgprompt_12_Visible ;
      private int edtCountryName_Enabled ;
      private int edtCityId_Enabled ;
      private int imgprompt_19_Visible ;
      private int edtCityName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV15GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z8AmusementParkName ;
      private string Z9AmusementParkWebsite ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAmusementParkName_Internalname ;
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
      private string edtAmusementParkId_Internalname ;
      private string edtAmusementParkId_Jsonclick ;
      private string A8AmusementParkName ;
      private string edtAmusementParkName_Jsonclick ;
      private string edtAmusementParkWebsite_Internalname ;
      private string A9AmusementParkWebsite ;
      private string edtAmusementParkWebsite_Jsonclick ;
      private string edtAmusementParkAddress_Internalname ;
      private string imgAmusementParkPhoto_Internalname ;
      private string sImgUrl ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string imgprompt_12_Internalname ;
      private string imgprompt_12_Link ;
      private string edtCountryName_Internalname ;
      private string A13CountryName ;
      private string edtCountryName_Jsonclick ;
      private string edtCityId_Internalname ;
      private string edtCityId_Jsonclick ;
      private string imgprompt_19_Internalname ;
      private string imgprompt_19_Link ;
      private string edtCityName_Internalname ;
      private string A20CityName ;
      private string edtCityName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z13CountryName ;
      private string Z20CityName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n19CityId ;
      private bool wbErr ;
      private bool A11AmusementParkPhoto_IsBlob ;
      private bool n7AmusementParkId ;
      private bool returnInSub ;
      private string Z10AmusementParkAddress ;
      private string A10AmusementParkAddress ;
      private string A40000AmusementParkPhoto_GXI ;
      private string Z40000AmusementParkPhoto_GXI ;
      private string A11AmusementParkPhoto ;
      private string Z11AmusementParkPhoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00024_A13CountryName ;
      private string[] T00025_A20CityName ;
      private short[] T00026_A7AmusementParkId ;
      private bool[] T00026_n7AmusementParkId ;
      private string[] T00026_A8AmusementParkName ;
      private string[] T00026_A9AmusementParkWebsite ;
      private string[] T00026_A10AmusementParkAddress ;
      private string[] T00026_A40000AmusementParkPhoto_GXI ;
      private string[] T00026_A13CountryName ;
      private string[] T00026_A20CityName ;
      private short[] T00026_A12CountryId ;
      private short[] T00026_A19CityId ;
      private bool[] T00026_n19CityId ;
      private string[] T00026_A11AmusementParkPhoto ;
      private string[] T00027_A8AmusementParkName ;
      private string[] T00028_A13CountryName ;
      private string[] T00029_A20CityName ;
      private short[] T000210_A7AmusementParkId ;
      private bool[] T000210_n7AmusementParkId ;
      private short[] T00023_A7AmusementParkId ;
      private bool[] T00023_n7AmusementParkId ;
      private string[] T00023_A8AmusementParkName ;
      private string[] T00023_A9AmusementParkWebsite ;
      private string[] T00023_A10AmusementParkAddress ;
      private string[] T00023_A40000AmusementParkPhoto_GXI ;
      private short[] T00023_A12CountryId ;
      private short[] T00023_A19CityId ;
      private bool[] T00023_n19CityId ;
      private string[] T00023_A11AmusementParkPhoto ;
      private short[] T000211_A7AmusementParkId ;
      private bool[] T000211_n7AmusementParkId ;
      private short[] T000212_A7AmusementParkId ;
      private bool[] T000212_n7AmusementParkId ;
      private short[] T00022_A7AmusementParkId ;
      private bool[] T00022_n7AmusementParkId ;
      private string[] T00022_A8AmusementParkName ;
      private string[] T00022_A9AmusementParkWebsite ;
      private string[] T00022_A10AmusementParkAddress ;
      private string[] T00022_A40000AmusementParkPhoto_GXI ;
      private short[] T00022_A12CountryId ;
      private short[] T00022_A19CityId ;
      private bool[] T00022_n19CityId ;
      private string[] T00022_A11AmusementParkPhoto ;
      private short[] T000213_A7AmusementParkId ;
      private bool[] T000213_n7AmusementParkId ;
      private string[] T000217_A13CountryName ;
      private string[] T000218_A20CityName ;
      private short[] T000219_A16GameId ;
      private short[] T000220_A1EmployeeId ;
      private short[] T000221_A7AmusementParkId ;
      private bool[] T000221_n7AmusementParkId ;
      private string[] T000222_A8AmusementParkName ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class amusementpark__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@AmusementParkName",GXType.NChar,20,0) ,
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@AmusementParkName",GXType.NChar,20,0) ,
          new ParDef("@AmusementParkWebsite",GXType.NChar,60,0) ,
          new ParDef("@AmusementParkAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@AmusementParkPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AmusementParkPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="AmusementPark", Fld="AmusementParkPhoto"} ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@AmusementParkName",GXType.NChar,20,0) ,
          new ParDef("@AmusementParkWebsite",GXType.NChar,60,0) ,
          new ParDef("@AmusementParkAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@AmusementParkPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AmusementParkPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="AmusementPark", Fld="AmusementParkPhoto"} ,
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@AmusementParkName",GXType.NChar,20,0) ,
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [AmusementParkId], [AmusementParkName], [AmusementParkWebsite], [AmusementParkAddress], [AmusementParkPhoto_GXI], [CountryId], [CityId], [AmusementParkPhoto] FROM [AmusementPark] WITH (UPDLOCK) WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [AmusementParkId], [AmusementParkName], [AmusementParkWebsite], [AmusementParkAddress], [AmusementParkPhoto_GXI], [CountryId], [CityId], [AmusementParkPhoto] FROM [AmusementPark] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT TM1.[AmusementParkId], TM1.[AmusementParkName], TM1.[AmusementParkWebsite], TM1.[AmusementParkAddress], TM1.[AmusementParkPhoto_GXI], T2.[CountryName], T3.[CityName], TM1.[CountryId], TM1.[CityId], TM1.[AmusementParkPhoto] FROM (([AmusementPark] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[CountryId]) LEFT JOIN [CountryCity] T3 ON T3.[CountryId] = TM1.[CountryId] AND T3.[CityId] = TM1.[CityId]) WHERE TM1.[AmusementParkId] = @AmusementParkId ORDER BY TM1.[AmusementParkId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT [AmusementParkName] FROM [AmusementPark] WHERE ([AmusementParkName] = @AmusementParkName) AND (Not ( [AmusementParkId] = @AmusementParkId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT [AmusementParkId] FROM [AmusementPark] WHERE [AmusementParkId] = @AmusementParkId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000211", "SELECT TOP 1 [AmusementParkId] FROM [AmusementPark] WHERE ( [AmusementParkId] > @AmusementParkId) ORDER BY [AmusementParkId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000212", "SELECT TOP 1 [AmusementParkId] FROM [AmusementPark] WHERE ( [AmusementParkId] < @AmusementParkId) ORDER BY [AmusementParkId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000213", "INSERT INTO [AmusementPark]([AmusementParkName], [AmusementParkWebsite], [AmusementParkAddress], [AmusementParkPhoto], [AmusementParkPhoto_GXI], [CountryId], [CityId]) VALUES(@AmusementParkName, @AmusementParkWebsite, @AmusementParkAddress, @AmusementParkPhoto, @AmusementParkPhoto_GXI, @CountryId, @CityId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000213)
             ,new CursorDef("T000214", "UPDATE [AmusementPark] SET [AmusementParkName]=@AmusementParkName, [AmusementParkWebsite]=@AmusementParkWebsite, [AmusementParkAddress]=@AmusementParkAddress, [CountryId]=@CountryId, [CityId]=@CityId  WHERE [AmusementParkId] = @AmusementParkId", GxErrorMask.GX_NOMASK,prmT000214)
             ,new CursorDef("T000215", "UPDATE [AmusementPark] SET [AmusementParkPhoto]=@AmusementParkPhoto, [AmusementParkPhoto_GXI]=@AmusementParkPhoto_GXI  WHERE [AmusementParkId] = @AmusementParkId", GxErrorMask.GX_NOMASK,prmT000215)
             ,new CursorDef("T000216", "DELETE FROM [AmusementPark]  WHERE [AmusementParkId] = @AmusementParkId", GxErrorMask.GX_NOMASK,prmT000216)
             ,new CursorDef("T000217", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000218", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000219", "SELECT TOP 1 [GameId] FROM [Game] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000220", "SELECT TOP 1 [EmployeeId] FROM [Employee] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000221", "SELECT [AmusementParkId] FROM [AmusementPark] ORDER BY [AmusementParkId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000222", "SELECT [AmusementParkName] FROM [AmusementPark] WHERE ([AmusementParkName] = @AmusementParkName) AND (Not ( [AmusementParkId] = @AmusementParkId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 60);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
       }
    }

 }

}
