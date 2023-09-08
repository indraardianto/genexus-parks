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
   public class game : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A7AmusementParkId = (short)(NumberUtil.Val( GetPar( "AmusementParkId"), "."));
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A7AmusementParkId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A14CategoryId = (short)(NumberUtil.Val( GetPar( "CategoryId"), "."));
            n14CategoryId = false;
            AssignAttri("", false, "A14CategoryId", StringUtil.LTrimStr( (decimal)(A14CategoryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A14CategoryId) ;
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
            Form.Meta.addItem("description", "Game", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtGameId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public game( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public game( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Game", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Game.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"GAMEID"+"'), id:'"+"GAMEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Game.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGameId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGameId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGameId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16GameId), 4, 0, ".", "")), StringUtil.LTrim( ((edtGameId_Enabled!=0) ? context.localUtil.Format( (decimal)(A16GameId), "ZZZ9") : context.localUtil.Format( (decimal)(A16GameId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGameId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGameId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGameName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGameName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGameName_Internalname, StringUtil.RTrim( A17GameName), StringUtil.RTrim( context.localUtil.Format( A17GameName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGameName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGameName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAmusementParkId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAmusementParkId_Internalname, "Amusement Park Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAmusementParkId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAmusementParkId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9") : context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmusementParkId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAmusementParkId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Game.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_7_Internalname, sImgUrl, imgprompt_7_Link, "", "", context.GetTheme( ), imgprompt_7_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Game.htm");
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
         GxWebStd.gx_label_element( context, edtAmusementParkName_Internalname, "Amusement Park Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAmusementParkName_Internalname, StringUtil.RTrim( A8AmusementParkName), StringUtil.RTrim( context.localUtil.Format( A8AmusementParkName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmusementParkName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAmusementParkName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryId_Internalname, "Category Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14CategoryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCategoryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A14CategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(A14CategoryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Game.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_14_Internalname, sImgUrl, imgprompt_14_Link, "", "", context.GetTheme( ), imgprompt_14_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryName_Internalname, "Category Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCategoryName_Internalname, StringUtil.RTrim( A15CategoryName), StringUtil.RTrim( context.localUtil.Format( A15CategoryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgGamePhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A18GamePhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000GamePhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : context.PathToRelativeUrl( A18GamePhoto));
         GxWebStd.gx_bitmap( context, imgGamePhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgGamePhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", "", "", 0, A18GamePhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Game.htm");
         AssignProp("", false, imgGamePhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : context.PathToRelativeUrl( A18GamePhoto)), true);
         AssignProp("", false, imgGamePhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A18GamePhoto_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Game.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Game.htm");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z16GameId = (short)(context.localUtil.CToN( cgiGet( "Z16GameId"), ".", ","));
            Z17GameName = cgiGet( "Z17GameName");
            Z7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( "Z7AmusementParkId"), ".", ","));
            Z14CategoryId = (short)(context.localUtil.CToN( cgiGet( "Z14CategoryId"), ".", ","));
            n14CategoryId = ((0==A14CategoryId) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A40000GamePhoto_GXI = cgiGet( "GAMEPHOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtGameId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtGameId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "GAMEID");
               AnyError = 1;
               GX_FocusControl = edtGameId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A16GameId = 0;
               AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            }
            else
            {
               A16GameId = (short)(context.localUtil.CToN( cgiGet( edtGameId_Internalname), ".", ","));
               AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            }
            A17GameName = cgiGet( edtGameName_Internalname);
            AssignAttri("", false, "A17GameName", A17GameName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AMUSEMENTPARKID");
               AnyError = 1;
               GX_FocusControl = edtAmusementParkId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A7AmusementParkId = 0;
               AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            }
            else
            {
               A7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ","));
               AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            }
            A8AmusementParkName = cgiGet( edtAmusementParkName_Internalname);
            AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A14CategoryId = 0;
               n14CategoryId = false;
               AssignAttri("", false, "A14CategoryId", StringUtil.LTrimStr( (decimal)(A14CategoryId), 4, 0));
            }
            else
            {
               A14CategoryId = (short)(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ","));
               n14CategoryId = false;
               AssignAttri("", false, "A14CategoryId", StringUtil.LTrimStr( (decimal)(A14CategoryId), 4, 0));
            }
            n14CategoryId = ((0==A14CategoryId) ? true : false);
            A15CategoryName = cgiGet( edtCategoryName_Internalname);
            AssignAttri("", false, "A15CategoryName", A15CategoryName);
            A18GamePhoto = cgiGet( imgGamePhoto_Internalname);
            AssignAttri("", false, "A18GamePhoto", A18GamePhoto);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgGamePhoto_Internalname, ref  A18GamePhoto, ref  A40000GamePhoto_GXI);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A16GameId = (short)(NumberUtil.Val( GetPar( "GameId"), "."));
               AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
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
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes055( ) ;
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

      protected void ResetCaption050( )
      {
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z17GameName = T00053_A17GameName[0];
               Z7AmusementParkId = T00053_A7AmusementParkId[0];
               Z14CategoryId = T00053_A14CategoryId[0];
            }
            else
            {
               Z17GameName = A17GameName;
               Z7AmusementParkId = A7AmusementParkId;
               Z14CategoryId = A14CategoryId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z16GameId = A16GameId;
            Z17GameName = A17GameName;
            Z18GamePhoto = A18GamePhoto;
            Z40000GamePhoto_GXI = A40000GamePhoto_GXI;
            Z7AmusementParkId = A7AmusementParkId;
            Z14CategoryId = A14CategoryId;
            Z8AmusementParkName = A8AmusementParkName;
            Z15CategoryName = A15CategoryName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"AMUSEMENTPARKID"+"'), id:'"+"AMUSEMENTPARKID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_14_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORYID"+"'), id:'"+"CATEGORYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
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
      }

      protected void Load055( )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A16GameId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
            A17GameName = T00056_A17GameName[0];
            AssignAttri("", false, "A17GameName", A17GameName);
            A8AmusementParkName = T00056_A8AmusementParkName[0];
            AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
            A15CategoryName = T00056_A15CategoryName[0];
            AssignAttri("", false, "A15CategoryName", A15CategoryName);
            A40000GamePhoto_GXI = T00056_A40000GamePhoto_GXI[0];
            AssignProp("", false, imgGamePhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : context.convertURL( context.PathToRelativeUrl( A18GamePhoto))), true);
            AssignProp("", false, imgGamePhoto_Internalname, "SrcSet", context.GetImageSrcSet( A18GamePhoto), true);
            A7AmusementParkId = T00056_A7AmusementParkId[0];
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            A14CategoryId = T00056_A14CategoryId[0];
            n14CategoryId = T00056_n14CategoryId[0];
            AssignAttri("", false, "A14CategoryId", StringUtil.LTrimStr( (decimal)(A14CategoryId), 4, 0));
            A18GamePhoto = T00056_A18GamePhoto[0];
            AssignAttri("", false, "A18GamePhoto", A18GamePhoto);
            AssignProp("", false, imgGamePhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : context.convertURL( context.PathToRelativeUrl( A18GamePhoto))), true);
            AssignProp("", false, imgGamePhoto_Internalname, "SrcSet", context.GetImageSrcSet( A18GamePhoto), true);
            ZM055( -1) ;
         }
         pr_default.close(4);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A7AmusementParkId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Amusement Park'.", "ForeignKeyNotFound", 1, "AMUSEMENTPARKID");
            AnyError = 1;
            GX_FocusControl = edtAmusementParkId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8AmusementParkName = T00054_A8AmusementParkName[0];
         AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {n14CategoryId, A14CategoryId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A14CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A15CategoryName = T00055_A15CategoryName[0];
         AssignAttri("", false, "A15CategoryName", A15CategoryName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( short A7AmusementParkId )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A7AmusementParkId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Amusement Park'.", "ForeignKeyNotFound", 1, "AMUSEMENTPARKID");
            AnyError = 1;
            GX_FocusControl = edtAmusementParkId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8AmusementParkName = T00057_A8AmusementParkName[0];
         AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8AmusementParkName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( short A14CategoryId )
      {
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {n14CategoryId, A14CategoryId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A14CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A15CategoryName = T00058_A15CategoryName[0];
         AssignAttri("", false, "A15CategoryName", A15CategoryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A15CategoryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey055( )
      {
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A16GameId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A16GameId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 1) ;
            RcdFound5 = 1;
            A16GameId = T00053_A16GameId[0];
            AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            A17GameName = T00053_A17GameName[0];
            AssignAttri("", false, "A17GameName", A17GameName);
            A40000GamePhoto_GXI = T00053_A40000GamePhoto_GXI[0];
            AssignProp("", false, imgGamePhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : context.convertURL( context.PathToRelativeUrl( A18GamePhoto))), true);
            AssignProp("", false, imgGamePhoto_Internalname, "SrcSet", context.GetImageSrcSet( A18GamePhoto), true);
            A7AmusementParkId = T00053_A7AmusementParkId[0];
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            A14CategoryId = T00053_A14CategoryId[0];
            n14CategoryId = T00053_n14CategoryId[0];
            AssignAttri("", false, "A14CategoryId", StringUtil.LTrimStr( (decimal)(A14CategoryId), 4, 0));
            A18GamePhoto = T00053_A18GamePhoto[0];
            AssignAttri("", false, "A18GamePhoto", A18GamePhoto);
            AssignProp("", false, imgGamePhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : context.convertURL( context.PathToRelativeUrl( A18GamePhoto))), true);
            AssignProp("", false, imgGamePhoto_Internalname, "SrcSet", context.GetImageSrcSet( A18GamePhoto), true);
            Z16GameId = A16GameId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A16GameId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000510_A16GameId[0] < A16GameId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000510_A16GameId[0] > A16GameId ) ) )
            {
               A16GameId = T000510_A16GameId[0];
               AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {A16GameId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000511_A16GameId[0] > A16GameId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000511_A16GameId[0] < A16GameId ) ) )
            {
               A16GameId = T000511_A16GameId[0];
               AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtGameId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A16GameId != Z16GameId )
               {
                  A16GameId = Z16GameId;
                  AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "GAMEID");
                  AnyError = 1;
                  GX_FocusControl = edtGameId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtGameId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtGameId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A16GameId != Z16GameId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtGameId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "GAMEID");
                     AnyError = 1;
                     GX_FocusControl = edtGameId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtGameId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A16GameId != Z16GameId )
         {
            A16GameId = Z16GameId;
            AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "GAMEID");
            AnyError = 1;
            GX_FocusControl = edtGameId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtGameId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "GAMEID");
            AnyError = 1;
            GX_FocusControl = edtGameId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtGameName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGameName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGameName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGameName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext055( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGameName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A16GameId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Game"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z17GameName, T00052_A17GameName[0]) != 0 ) || ( Z7AmusementParkId != T00052_A7AmusementParkId[0] ) || ( Z14CategoryId != T00052_A14CategoryId[0] ) )
            {
               if ( StringUtil.StrCmp(Z17GameName, T00052_A17GameName[0]) != 0 )
               {
                  GXUtil.WriteLog("game:[seudo value changed for attri]"+"GameName");
                  GXUtil.WriteLogRaw("Old: ",Z17GameName);
                  GXUtil.WriteLogRaw("Current: ",T00052_A17GameName[0]);
               }
               if ( Z7AmusementParkId != T00052_A7AmusementParkId[0] )
               {
                  GXUtil.WriteLog("game:[seudo value changed for attri]"+"AmusementParkId");
                  GXUtil.WriteLogRaw("Old: ",Z7AmusementParkId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A7AmusementParkId[0]);
               }
               if ( Z14CategoryId != T00052_A14CategoryId[0] )
               {
                  GXUtil.WriteLog("game:[seudo value changed for attri]"+"CategoryId");
                  GXUtil.WriteLogRaw("Old: ",Z14CategoryId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A14CategoryId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Game"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000512 */
                     pr_default.execute(10, new Object[] {A17GameName, A18GamePhoto, A40000GamePhoto_GXI, A7AmusementParkId, n14CategoryId, A14CategoryId});
                     A16GameId = T000512_A16GameId[0];
                     AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Game");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000513 */
                     pr_default.execute(11, new Object[] {A17GameName, A7AmusementParkId, n14CategoryId, A14CategoryId, A16GameId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Game");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Game"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption050( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000514 */
            pr_default.execute(12, new Object[] {A18GamePhoto, A40000GamePhoto_GXI, A16GameId});
            pr_default.close(12);
            dsDefault.SmartCacheProvider.SetUpdated("Game");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000515 */
                  pr_default.execute(13, new Object[] {A16GameId});
                  pr_default.close(13);
                  dsDefault.SmartCacheProvider.SetUpdated("Game");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound5 == 0 )
                        {
                           InitAll055( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption050( ) ;
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000516 */
            pr_default.execute(14, new Object[] {A7AmusementParkId});
            A8AmusementParkName = T000516_A8AmusementParkName[0];
            AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
            pr_default.close(14);
            /* Using cursor T000517 */
            pr_default.execute(15, new Object[] {n14CategoryId, A14CategoryId});
            A15CategoryName = T000517_A15CategoryName[0];
            AssignAttri("", false, "A15CategoryName", A15CategoryName);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000518 */
            pr_default.execute(16, new Object[] {A16GameId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Repair"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.CommitDataStores("game",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.RollbackDataStores("game",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Using cursor T000519 */
         pr_default.execute(17);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound5 = 1;
            A16GameId = T000519_A16GameId[0];
            AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound5 = 1;
            A16GameId = T000519_A16GameId[0];
            AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtGameId_Enabled = 0;
         AssignProp("", false, edtGameId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGameId_Enabled), 5, 0), true);
         edtGameName_Enabled = 0;
         AssignProp("", false, edtGameName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGameName_Enabled), 5, 0), true);
         edtAmusementParkId_Enabled = 0;
         AssignProp("", false, edtAmusementParkId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkId_Enabled), 5, 0), true);
         edtAmusementParkName_Enabled = 0;
         AssignProp("", false, edtAmusementParkName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkName_Enabled), 5, 0), true);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), true);
         imgGamePhoto_Enabled = 0;
         AssignProp("", false, imgGamePhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgGamePhoto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.AddJavascriptSource("gxcfg.js", "?20236199442859", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("game.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z16GameId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16GameId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17GameName", StringUtil.RTrim( Z17GameName));
         GxWebStd.gx_hidden_field( context, "Z7AmusementParkId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AmusementParkId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "GAMEPHOTO_GXI", A40000GamePhoto_GXI);
         GXCCtlgxBlob = "GAMEPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A18GamePhoto);
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
         return formatLink("game.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Game" ;
      }

      public override string GetPgmdesc( )
      {
         return "Game" ;
      }

      protected void InitializeNonKey055( )
      {
         A17GameName = "";
         AssignAttri("", false, "A17GameName", A17GameName);
         A7AmusementParkId = 0;
         AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
         A8AmusementParkName = "";
         AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
         A14CategoryId = 0;
         n14CategoryId = false;
         AssignAttri("", false, "A14CategoryId", StringUtil.LTrimStr( (decimal)(A14CategoryId), 4, 0));
         n14CategoryId = ((0==A14CategoryId) ? true : false);
         A15CategoryName = "";
         AssignAttri("", false, "A15CategoryName", A15CategoryName);
         A18GamePhoto = "";
         AssignAttri("", false, "A18GamePhoto", A18GamePhoto);
         AssignProp("", false, imgGamePhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : context.convertURL( context.PathToRelativeUrl( A18GamePhoto))), true);
         AssignProp("", false, imgGamePhoto_Internalname, "SrcSet", context.GetImageSrcSet( A18GamePhoto), true);
         A40000GamePhoto_GXI = "";
         AssignProp("", false, imgGamePhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : context.convertURL( context.PathToRelativeUrl( A18GamePhoto))), true);
         AssignProp("", false, imgGamePhoto_Internalname, "SrcSet", context.GetImageSrcSet( A18GamePhoto), true);
         Z17GameName = "";
         Z7AmusementParkId = 0;
         Z14CategoryId = 0;
      }

      protected void InitAll055( )
      {
         A16GameId = 0;
         AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
         InitializeNonKey055( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20236199442864", true, true);
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
         context.AddJavascriptSource("game.js", "?20236199442865", false, true);
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
         edtGameId_Internalname = "GAMEID";
         edtGameName_Internalname = "GAMENAME";
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID";
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         imgGamePhoto_Internalname = "GAMEPHOTO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_7_Internalname = "PROMPT_7";
         imgprompt_14_Internalname = "PROMPT_14";
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
         Form.Caption = "Game";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgGamePhoto_Enabled = 1;
         edtCategoryName_Jsonclick = "";
         edtCategoryName_Enabled = 0;
         imgprompt_14_Visible = 1;
         imgprompt_14_Link = "";
         edtCategoryId_Jsonclick = "";
         edtCategoryId_Enabled = 1;
         edtAmusementParkName_Jsonclick = "";
         edtAmusementParkName_Enabled = 0;
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         edtAmusementParkId_Jsonclick = "";
         edtAmusementParkId_Enabled = 1;
         edtGameName_Jsonclick = "";
         edtGameName_Enabled = 1;
         edtGameId_Jsonclick = "";
         edtGameId_Enabled = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtGameName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Gameid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A17GameName", StringUtil.RTrim( A17GameName));
         AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")));
         AssignAttri("", false, "A14CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14CategoryId), 4, 0, ".", "")));
         AssignAttri("", false, "A18GamePhoto", context.PathToRelativeUrl( A18GamePhoto));
         GXCCtlgxBlob = "GAMEPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A18GamePhoto));
         AssignAttri("", false, "A40000GamePhoto_GXI", A40000GamePhoto_GXI);
         AssignAttri("", false, "A8AmusementParkName", StringUtil.RTrim( A8AmusementParkName));
         AssignAttri("", false, "A15CategoryName", StringUtil.RTrim( A15CategoryName));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z16GameId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16GameId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17GameName", StringUtil.RTrim( Z17GameName));
         GxWebStd.gx_hidden_field( context, "Z7AmusementParkId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AmusementParkId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18GamePhoto", context.PathToRelativeUrl( Z18GamePhoto));
         GxWebStd.gx_hidden_field( context, "Z40000GamePhoto_GXI", Z40000GamePhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z8AmusementParkName", StringUtil.RTrim( Z8AmusementParkName));
         GxWebStd.gx_hidden_field( context, "Z15CategoryName", StringUtil.RTrim( Z15CategoryName));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Amusementparkid( )
      {
         /* Using cursor T000516 */
         pr_default.execute(14, new Object[] {A7AmusementParkId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'Amusement Park'.", "ForeignKeyNotFound", 1, "AMUSEMENTPARKID");
            AnyError = 1;
            GX_FocusControl = edtAmusementParkId_Internalname;
         }
         A8AmusementParkName = T000516_A8AmusementParkName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8AmusementParkName", StringUtil.RTrim( A8AmusementParkName));
      }

      public void Valid_Categoryid( )
      {
         n14CategoryId = false;
         /* Using cursor T000517 */
         pr_default.execute(15, new Object[] {n14CategoryId, A14CategoryId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A14CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
            }
         }
         A15CategoryName = T000517_A15CategoryName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A15CategoryName", StringUtil.RTrim( A15CategoryName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_GAMEID","{handler:'Valid_Gameid',iparms:[{av:'A16GameId',fld:'GAMEID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_GAMEID",",oparms:[{av:'A17GameName',fld:'GAMENAME',pic:''},{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9'},{av:'A14CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A18GamePhoto',fld:'GAMEPHOTO',pic:''},{av:'A40000GamePhoto_GXI',fld:'GAMEPHOTO_GXI',pic:''},{av:'A8AmusementParkName',fld:'AMUSEMENTPARKNAME',pic:''},{av:'A15CategoryName',fld:'CATEGORYNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z16GameId'},{av:'Z17GameName'},{av:'Z7AmusementParkId'},{av:'Z14CategoryId'},{av:'Z18GamePhoto'},{av:'Z40000GamePhoto_GXI'},{av:'Z8AmusementParkName'},{av:'Z15CategoryName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_AMUSEMENTPARKID","{handler:'Valid_Amusementparkid',iparms:[{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9'},{av:'A8AmusementParkName',fld:'AMUSEMENTPARKNAME',pic:''}]");
         setEventMetadata("VALID_AMUSEMENTPARKID",",oparms:[{av:'A8AmusementParkName',fld:'AMUSEMENTPARKNAME',pic:''}]}");
         setEventMetadata("VALID_CATEGORYID","{handler:'Valid_Categoryid',iparms:[{av:'A14CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A15CategoryName',fld:'CATEGORYNAME',pic:''}]");
         setEventMetadata("VALID_CATEGORYID",",oparms:[{av:'A15CategoryName',fld:'CATEGORYNAME',pic:''}]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z17GameName = "";
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
         A17GameName = "";
         sImgUrl = "";
         A8AmusementParkName = "";
         A15CategoryName = "";
         A18GamePhoto = "";
         A40000GamePhoto_GXI = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z18GamePhoto = "";
         Z40000GamePhoto_GXI = "";
         Z8AmusementParkName = "";
         Z15CategoryName = "";
         T00056_A16GameId = new short[1] ;
         T00056_A17GameName = new string[] {""} ;
         T00056_A8AmusementParkName = new string[] {""} ;
         T00056_A15CategoryName = new string[] {""} ;
         T00056_A40000GamePhoto_GXI = new string[] {""} ;
         T00056_A7AmusementParkId = new short[1] ;
         T00056_A14CategoryId = new short[1] ;
         T00056_n14CategoryId = new bool[] {false} ;
         T00056_A18GamePhoto = new string[] {""} ;
         T00054_A8AmusementParkName = new string[] {""} ;
         T00055_A15CategoryName = new string[] {""} ;
         T00057_A8AmusementParkName = new string[] {""} ;
         T00058_A15CategoryName = new string[] {""} ;
         T00059_A16GameId = new short[1] ;
         T00053_A16GameId = new short[1] ;
         T00053_A17GameName = new string[] {""} ;
         T00053_A40000GamePhoto_GXI = new string[] {""} ;
         T00053_A7AmusementParkId = new short[1] ;
         T00053_A14CategoryId = new short[1] ;
         T00053_n14CategoryId = new bool[] {false} ;
         T00053_A18GamePhoto = new string[] {""} ;
         sMode5 = "";
         T000510_A16GameId = new short[1] ;
         T000511_A16GameId = new short[1] ;
         T00052_A16GameId = new short[1] ;
         T00052_A17GameName = new string[] {""} ;
         T00052_A40000GamePhoto_GXI = new string[] {""} ;
         T00052_A7AmusementParkId = new short[1] ;
         T00052_A14CategoryId = new short[1] ;
         T00052_n14CategoryId = new bool[] {false} ;
         T00052_A18GamePhoto = new string[] {""} ;
         T000512_A16GameId = new short[1] ;
         T000516_A8AmusementParkName = new string[] {""} ;
         T000517_A15CategoryName = new string[] {""} ;
         T000518_A22RepairId = new short[1] ;
         T000519_A16GameId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ17GameName = "";
         ZZ18GamePhoto = "";
         ZZ40000GamePhoto_GXI = "";
         ZZ8AmusementParkName = "";
         ZZ15CategoryName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.game__default(),
            new Object[][] {
                new Object[] {
               T00052_A16GameId, T00052_A17GameName, T00052_A40000GamePhoto_GXI, T00052_A7AmusementParkId, T00052_A14CategoryId, T00052_n14CategoryId, T00052_A18GamePhoto
               }
               , new Object[] {
               T00053_A16GameId, T00053_A17GameName, T00053_A40000GamePhoto_GXI, T00053_A7AmusementParkId, T00053_A14CategoryId, T00053_n14CategoryId, T00053_A18GamePhoto
               }
               , new Object[] {
               T00054_A8AmusementParkName
               }
               , new Object[] {
               T00055_A15CategoryName
               }
               , new Object[] {
               T00056_A16GameId, T00056_A17GameName, T00056_A8AmusementParkName, T00056_A15CategoryName, T00056_A40000GamePhoto_GXI, T00056_A7AmusementParkId, T00056_A14CategoryId, T00056_n14CategoryId, T00056_A18GamePhoto
               }
               , new Object[] {
               T00057_A8AmusementParkName
               }
               , new Object[] {
               T00058_A15CategoryName
               }
               , new Object[] {
               T00059_A16GameId
               }
               , new Object[] {
               T000510_A16GameId
               }
               , new Object[] {
               T000511_A16GameId
               }
               , new Object[] {
               T000512_A16GameId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000516_A8AmusementParkName
               }
               , new Object[] {
               T000517_A15CategoryName
               }
               , new Object[] {
               T000518_A22RepairId
               }
               , new Object[] {
               T000519_A16GameId
               }
            }
         );
      }

      private short Z16GameId ;
      private short Z7AmusementParkId ;
      private short Z14CategoryId ;
      private short GxWebError ;
      private short A7AmusementParkId ;
      private short A14CategoryId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A16GameId ;
      private short GX_JID ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ16GameId ;
      private short ZZ7AmusementParkId ;
      private short ZZ14CategoryId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtGameId_Enabled ;
      private int edtGameName_Enabled ;
      private int edtAmusementParkId_Enabled ;
      private int imgprompt_7_Visible ;
      private int edtAmusementParkName_Enabled ;
      private int edtCategoryId_Enabled ;
      private int imgprompt_14_Visible ;
      private int edtCategoryName_Enabled ;
      private int imgGamePhoto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z17GameName ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtGameId_Internalname ;
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
      private string edtGameId_Jsonclick ;
      private string edtGameName_Internalname ;
      private string A17GameName ;
      private string edtGameName_Jsonclick ;
      private string edtAmusementParkId_Internalname ;
      private string edtAmusementParkId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_7_Internalname ;
      private string imgprompt_7_Link ;
      private string edtAmusementParkName_Internalname ;
      private string A8AmusementParkName ;
      private string edtAmusementParkName_Jsonclick ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryId_Jsonclick ;
      private string imgprompt_14_Internalname ;
      private string imgprompt_14_Link ;
      private string edtCategoryName_Internalname ;
      private string A15CategoryName ;
      private string edtCategoryName_Jsonclick ;
      private string imgGamePhoto_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z8AmusementParkName ;
      private string Z15CategoryName ;
      private string sMode5 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ17GameName ;
      private string ZZ8AmusementParkName ;
      private string ZZ15CategoryName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n14CategoryId ;
      private bool wbErr ;
      private bool A18GamePhoto_IsBlob ;
      private string A40000GamePhoto_GXI ;
      private string Z40000GamePhoto_GXI ;
      private string ZZ40000GamePhoto_GXI ;
      private string A18GamePhoto ;
      private string Z18GamePhoto ;
      private string ZZ18GamePhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00056_A16GameId ;
      private string[] T00056_A17GameName ;
      private string[] T00056_A8AmusementParkName ;
      private string[] T00056_A15CategoryName ;
      private string[] T00056_A40000GamePhoto_GXI ;
      private short[] T00056_A7AmusementParkId ;
      private short[] T00056_A14CategoryId ;
      private bool[] T00056_n14CategoryId ;
      private string[] T00056_A18GamePhoto ;
      private string[] T00054_A8AmusementParkName ;
      private string[] T00055_A15CategoryName ;
      private string[] T00057_A8AmusementParkName ;
      private string[] T00058_A15CategoryName ;
      private short[] T00059_A16GameId ;
      private short[] T00053_A16GameId ;
      private string[] T00053_A17GameName ;
      private string[] T00053_A40000GamePhoto_GXI ;
      private short[] T00053_A7AmusementParkId ;
      private short[] T00053_A14CategoryId ;
      private bool[] T00053_n14CategoryId ;
      private string[] T00053_A18GamePhoto ;
      private short[] T000510_A16GameId ;
      private short[] T000511_A16GameId ;
      private short[] T00052_A16GameId ;
      private string[] T00052_A17GameName ;
      private string[] T00052_A40000GamePhoto_GXI ;
      private short[] T00052_A7AmusementParkId ;
      private short[] T00052_A14CategoryId ;
      private bool[] T00052_n14CategoryId ;
      private string[] T00052_A18GamePhoto ;
      private short[] T000512_A16GameId ;
      private string[] T000516_A8AmusementParkName ;
      private string[] T000517_A15CategoryName ;
      private short[] T000518_A22RepairId ;
      private short[] T000519_A16GameId ;
      private GXWebForm Form ;
   }

   public class game__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@GameName",GXType.NChar,50,0) ,
          new ParDef("@GamePhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@GamePhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Game", Fld="GamePhoto"} ,
          new ParDef("@AmusementParkId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@GameName",GXType.NChar,50,0) ,
          new ParDef("@AmusementParkId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@GamePhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@GamePhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Game", Fld="GamePhoto"} ,
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000518;
          prmT000518 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000519;
          prmT000519 = new Object[] {
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0)
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [GameId], [GameName], [GamePhoto_GXI], [AmusementParkId], [CategoryId], [GamePhoto] FROM [Game] WITH (UPDLOCK) WHERE [GameId] = @GameId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [GameId], [GameName], [GamePhoto_GXI], [AmusementParkId], [CategoryId], [GamePhoto] FROM [Game] WHERE [GameId] = @GameId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [AmusementParkName] FROM [AmusementPark] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT TM1.[GameId], TM1.[GameName], T2.[AmusementParkName], T3.[CategoryName], TM1.[GamePhoto_GXI], TM1.[AmusementParkId], TM1.[CategoryId], TM1.[GamePhoto] FROM (([Game] TM1 INNER JOIN [AmusementPark] T2 ON T2.[AmusementParkId] = TM1.[AmusementParkId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[GameId] = @GameId ORDER BY TM1.[GameId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [AmusementParkName] FROM [AmusementPark] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [GameId] FROM [Game] WHERE [GameId] = @GameId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT TOP 1 [GameId] FROM [Game] WHERE ( [GameId] > @GameId) ORDER BY [GameId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000511", "SELECT TOP 1 [GameId] FROM [Game] WHERE ( [GameId] < @GameId) ORDER BY [GameId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000512", "INSERT INTO [Game]([GameName], [GamePhoto], [GamePhoto_GXI], [AmusementParkId], [CategoryId]) VALUES(@GameName, @GamePhoto, @GamePhoto_GXI, @AmusementParkId, @CategoryId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000512)
             ,new CursorDef("T000513", "UPDATE [Game] SET [GameName]=@GameName, [AmusementParkId]=@AmusementParkId, [CategoryId]=@CategoryId  WHERE [GameId] = @GameId", GxErrorMask.GX_NOMASK,prmT000513)
             ,new CursorDef("T000514", "UPDATE [Game] SET [GamePhoto]=@GamePhoto, [GamePhoto_GXI]=@GamePhoto_GXI  WHERE [GameId] = @GameId", GxErrorMask.GX_NOMASK,prmT000514)
             ,new CursorDef("T000515", "DELETE FROM [Game]  WHERE [GameId] = @GameId", GxErrorMask.GX_NOMASK,prmT000515)
             ,new CursorDef("T000516", "SELECT [AmusementParkName] FROM [AmusementPark] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000517", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000518", "SELECT TOP 1 [RepairId] FROM [Repair] WHERE [GameId] = @GameId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000519", "SELECT [GameId] FROM [Game] ORDER BY [GameId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
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
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
