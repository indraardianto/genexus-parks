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
   public class employee : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A7AmusementParkId = (short)(NumberUtil.Val( GetPar( "AmusementParkId"), "."));
            n7AmusementParkId = false;
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A7AmusementParkId) ;
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
            Form.Meta.addItem("description", "Employee", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public employee( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public employee( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Employee", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Employee.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPLOYEEID"+"'), id:'"+"EMPLOYEEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Employee.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmployeeId), 4, 0, ".", "")), StringUtil.LTrim( ((edtEmployeeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EmployeeId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EmployeeId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeName_Internalname, StringUtil.RTrim( A2EmployeeName), StringUtil.RTrim( context.localUtil.Format( A2EmployeeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeLastName_Internalname, "Last Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeLastName_Internalname, StringUtil.RTrim( A3EmployeeLastName), StringUtil.RTrim( context.localUtil.Format( A3EmployeeLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeLastName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeAddress_Internalname, "Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEmployeeAddress_Internalname, A4EmployeeAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A4EmployeeAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtEmployeeAddress_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeePhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeePhone_Internalname, "Phone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A5EmployeePhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeePhone_Internalname, StringUtil.RTrim( A5EmployeePhone), StringUtil.RTrim( context.localUtil.Format( A5EmployeePhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtEmployeePhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeePhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeEmail_Internalname, A6EmployeeEmail, StringUtil.RTrim( context.localUtil.Format( A6EmployeeEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A6EmployeeEmail, "", "", "", edtEmployeeEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Employee.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAmusementParkId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAmusementParkId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9") : context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmusementParkId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAmusementParkId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Employee.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_7_Internalname, sImgUrl, imgprompt_7_Link, "", "", context.GetTheme( ), imgprompt_7_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Employee.htm");
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
         GxWebStd.gx_single_line_edit( context, edtAmusementParkName_Internalname, StringUtil.RTrim( A8AmusementParkName), StringUtil.RTrim( context.localUtil.Format( A8AmusementParkName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAmusementParkName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAmusementParkName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeAddedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeAddedDate_Internalname, "Added Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEmployeeAddedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEmployeeAddedDate_Internalname, context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"), context.localUtil.Format( A21EmployeeAddedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeAddedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeAddedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Employee.htm");
         GxWebStd.gx_bitmap( context, edtEmployeeAddedDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEmployeeAddedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Employee.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
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
            Z1EmployeeId = (short)(context.localUtil.CToN( cgiGet( "Z1EmployeeId"), ".", ","));
            Z2EmployeeName = cgiGet( "Z2EmployeeName");
            Z3EmployeeLastName = cgiGet( "Z3EmployeeLastName");
            Z4EmployeeAddress = cgiGet( "Z4EmployeeAddress");
            Z5EmployeePhone = cgiGet( "Z5EmployeePhone");
            Z6EmployeeEmail = cgiGet( "Z6EmployeeEmail");
            Z21EmployeeAddedDate = context.localUtil.CToD( cgiGet( "Z21EmployeeAddedDate"), 0);
            Z7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( "Z7AmusementParkId"), ".", ","));
            n7AmusementParkId = ((0==A7AmusementParkId) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
            Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEEID");
               AnyError = 1;
               GX_FocusControl = edtEmployeeId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1EmployeeId = 0;
               AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
            }
            else
            {
               A1EmployeeId = (short)(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","));
               AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
            }
            A2EmployeeName = cgiGet( edtEmployeeName_Internalname);
            AssignAttri("", false, "A2EmployeeName", A2EmployeeName);
            A3EmployeeLastName = cgiGet( edtEmployeeLastName_Internalname);
            AssignAttri("", false, "A3EmployeeLastName", A3EmployeeLastName);
            A4EmployeeAddress = cgiGet( edtEmployeeAddress_Internalname);
            AssignAttri("", false, "A4EmployeeAddress", A4EmployeeAddress);
            A5EmployeePhone = cgiGet( edtEmployeePhone_Internalname);
            AssignAttri("", false, "A5EmployeePhone", A5EmployeePhone);
            A6EmployeeEmail = cgiGet( edtEmployeeEmail_Internalname);
            AssignAttri("", false, "A6EmployeeEmail", A6EmployeeEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AMUSEMENTPARKID");
               AnyError = 1;
               GX_FocusControl = edtAmusementParkId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A7AmusementParkId = 0;
               n7AmusementParkId = false;
               AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            }
            else
            {
               A7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ","));
               n7AmusementParkId = false;
               AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            }
            n7AmusementParkId = ((0==A7AmusementParkId) ? true : false);
            A8AmusementParkName = cgiGet( edtAmusementParkName_Internalname);
            AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
            if ( context.localUtil.VCDate( cgiGet( edtEmployeeAddedDate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Employee Added Date"}), 1, "EMPLOYEEADDEDDATE");
               AnyError = 1;
               GX_FocusControl = edtEmployeeAddedDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A21EmployeeAddedDate = DateTime.MinValue;
               AssignAttri("", false, "A21EmployeeAddedDate", context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"));
            }
            else
            {
               A21EmployeeAddedDate = context.localUtil.CToD( cgiGet( edtEmployeeAddedDate_Internalname), 1);
               AssignAttri("", false, "A21EmployeeAddedDate", context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
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
               A1EmployeeId = (short)(NumberUtil.Val( GetPar( "EmployeeId"), "."));
               AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
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
               InitAll011( ) ;
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
         DisableAttributes011( ) ;
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

      protected void ResetCaption010( )
      {
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2EmployeeName = T00013_A2EmployeeName[0];
               Z3EmployeeLastName = T00013_A3EmployeeLastName[0];
               Z4EmployeeAddress = T00013_A4EmployeeAddress[0];
               Z5EmployeePhone = T00013_A5EmployeePhone[0];
               Z6EmployeeEmail = T00013_A6EmployeeEmail[0];
               Z21EmployeeAddedDate = T00013_A21EmployeeAddedDate[0];
               Z7AmusementParkId = T00013_A7AmusementParkId[0];
            }
            else
            {
               Z2EmployeeName = A2EmployeeName;
               Z3EmployeeLastName = A3EmployeeLastName;
               Z4EmployeeAddress = A4EmployeeAddress;
               Z5EmployeePhone = A5EmployeePhone;
               Z6EmployeeEmail = A6EmployeeEmail;
               Z21EmployeeAddedDate = A21EmployeeAddedDate;
               Z7AmusementParkId = A7AmusementParkId;
            }
         }
         if ( GX_JID == -7 )
         {
            Z1EmployeeId = A1EmployeeId;
            Z2EmployeeName = A2EmployeeName;
            Z3EmployeeLastName = A3EmployeeLastName;
            Z4EmployeeAddress = A4EmployeeAddress;
            Z5EmployeePhone = A5EmployeePhone;
            Z6EmployeeEmail = A6EmployeeEmail;
            Z21EmployeeAddedDate = A21EmployeeAddedDate;
            Z7AmusementParkId = A7AmusementParkId;
            Z8AmusementParkName = A8AmusementParkName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"AMUSEMENTPARKID"+"'), id:'"+"AMUSEMENTPARKID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A21EmployeeAddedDate) && ( Gx_BScreen == 0 ) )
         {
            A21EmployeeAddedDate = Gx_date;
            AssignAttri("", false, "A21EmployeeAddedDate", context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"));
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1EmployeeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A2EmployeeName = T00015_A2EmployeeName[0];
            AssignAttri("", false, "A2EmployeeName", A2EmployeeName);
            A3EmployeeLastName = T00015_A3EmployeeLastName[0];
            AssignAttri("", false, "A3EmployeeLastName", A3EmployeeLastName);
            A4EmployeeAddress = T00015_A4EmployeeAddress[0];
            AssignAttri("", false, "A4EmployeeAddress", A4EmployeeAddress);
            A5EmployeePhone = T00015_A5EmployeePhone[0];
            AssignAttri("", false, "A5EmployeePhone", A5EmployeePhone);
            A6EmployeeEmail = T00015_A6EmployeeEmail[0];
            AssignAttri("", false, "A6EmployeeEmail", A6EmployeeEmail);
            A8AmusementParkName = T00015_A8AmusementParkName[0];
            AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
            A21EmployeeAddedDate = T00015_A21EmployeeAddedDate[0];
            AssignAttri("", false, "A21EmployeeAddedDate", context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"));
            A7AmusementParkId = T00015_A7AmusementParkId[0];
            n7AmusementParkId = T00015_n7AmusementParkId[0];
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            ZM011( -7) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2EmployeeName)) )
         {
            GX_msglist.addItem("Enter Employee Name", 1, "EMPLOYEENAME");
            AnyError = 1;
            GX_FocusControl = edtEmployeeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A3EmployeeLastName)) )
         {
            GX_msglist.addItem("Enter Employee Last Name", 1, "EMPLOYEELASTNAME");
            AnyError = 1;
            GX_FocusControl = edtEmployeeLastName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A5EmployeePhone)) )
         {
            GX_msglist.addItem("The phone is empty", 0, "EMPLOYEEPHONE");
         }
         if ( ! ( GxRegex.IsMatch(A6EmployeeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Employee Email does not match the specified pattern", "OutOfRange", 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A7AmusementParkId) ) )
            {
               GX_msglist.addItem("No matching 'Amusement Park'.", "ForeignKeyNotFound", 1, "AMUSEMENTPARKID");
               AnyError = 1;
               GX_FocusControl = edtAmusementParkId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A8AmusementParkName = T00014_A8AmusementParkName[0];
         AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A21EmployeeAddedDate) || ( DateTimeUtil.ResetTime ( A21EmployeeAddedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Employee Added Date is out of range", "OutOfRange", 1, "EMPLOYEEADDEDDATE");
            AnyError = 1;
            GX_FocusControl = edtEmployeeAddedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( short A7AmusementParkId )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A7AmusementParkId) ) )
            {
               GX_msglist.addItem("No matching 'Amusement Park'.", "ForeignKeyNotFound", 1, "AMUSEMENTPARKID");
               AnyError = 1;
               GX_FocusControl = edtAmusementParkId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A8AmusementParkName = T00016_A8AmusementParkName[0];
         AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8AmusementParkName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey011( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1EmployeeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1EmployeeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 7) ;
            RcdFound1 = 1;
            A1EmployeeId = T00013_A1EmployeeId[0];
            AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
            A2EmployeeName = T00013_A2EmployeeName[0];
            AssignAttri("", false, "A2EmployeeName", A2EmployeeName);
            A3EmployeeLastName = T00013_A3EmployeeLastName[0];
            AssignAttri("", false, "A3EmployeeLastName", A3EmployeeLastName);
            A4EmployeeAddress = T00013_A4EmployeeAddress[0];
            AssignAttri("", false, "A4EmployeeAddress", A4EmployeeAddress);
            A5EmployeePhone = T00013_A5EmployeePhone[0];
            AssignAttri("", false, "A5EmployeePhone", A5EmployeePhone);
            A6EmployeeEmail = T00013_A6EmployeeEmail[0];
            AssignAttri("", false, "A6EmployeeEmail", A6EmployeeEmail);
            A21EmployeeAddedDate = T00013_A21EmployeeAddedDate[0];
            AssignAttri("", false, "A21EmployeeAddedDate", context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"));
            A7AmusementParkId = T00013_A7AmusementParkId[0];
            n7AmusementParkId = T00013_n7AmusementParkId[0];
            AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
            Z1EmployeeId = A1EmployeeId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         RcdFound1 = 0;
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A1EmployeeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1EmployeeId[0] < A1EmployeeId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1EmployeeId[0] > A1EmployeeId ) ) )
            {
               A1EmployeeId = T00018_A1EmployeeId[0];
               AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1EmployeeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1EmployeeId[0] > A1EmployeeId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1EmployeeId[0] < A1EmployeeId ) ) )
            {
               A1EmployeeId = T00019_A1EmployeeId[0];
               AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1EmployeeId != Z1EmployeeId )
               {
                  A1EmployeeId = Z1EmployeeId;
                  AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPLOYEEID");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmployeeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtEmployeeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1EmployeeId != Z1EmployeeId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtEmployeeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPLOYEEID");
                     AnyError = 1;
                     GX_FocusControl = edtEmployeeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtEmployeeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1EmployeeId != Z1EmployeeId )
         {
            A1EmployeeId = Z1EmployeeId;
            AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmployeeId_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtEmployeeName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmployeeName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmployeeName_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmployeeName_Internalname;
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
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext011( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmployeeName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1EmployeeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2EmployeeName, T00012_A2EmployeeName[0]) != 0 ) || ( StringUtil.StrCmp(Z3EmployeeLastName, T00012_A3EmployeeLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z4EmployeeAddress, T00012_A4EmployeeAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z5EmployeePhone, T00012_A5EmployeePhone[0]) != 0 ) || ( StringUtil.StrCmp(Z6EmployeeEmail, T00012_A6EmployeeEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z21EmployeeAddedDate ) != DateTimeUtil.ResetTime ( T00012_A21EmployeeAddedDate[0] ) ) || ( Z7AmusementParkId != T00012_A7AmusementParkId[0] ) )
            {
               if ( StringUtil.StrCmp(Z2EmployeeName, T00012_A2EmployeeName[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeName");
                  GXUtil.WriteLogRaw("Old: ",Z2EmployeeName);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2EmployeeName[0]);
               }
               if ( StringUtil.StrCmp(Z3EmployeeLastName, T00012_A3EmployeeLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeLastName");
                  GXUtil.WriteLogRaw("Old: ",Z3EmployeeLastName);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3EmployeeLastName[0]);
               }
               if ( StringUtil.StrCmp(Z4EmployeeAddress, T00012_A4EmployeeAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeAddress");
                  GXUtil.WriteLogRaw("Old: ",Z4EmployeeAddress);
                  GXUtil.WriteLogRaw("Current: ",T00012_A4EmployeeAddress[0]);
               }
               if ( StringUtil.StrCmp(Z5EmployeePhone, T00012_A5EmployeePhone[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeePhone");
                  GXUtil.WriteLogRaw("Old: ",Z5EmployeePhone);
                  GXUtil.WriteLogRaw("Current: ",T00012_A5EmployeePhone[0]);
               }
               if ( StringUtil.StrCmp(Z6EmployeeEmail, T00012_A6EmployeeEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeEmail");
                  GXUtil.WriteLogRaw("Old: ",Z6EmployeeEmail);
                  GXUtil.WriteLogRaw("Current: ",T00012_A6EmployeeEmail[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z21EmployeeAddedDate ) != DateTimeUtil.ResetTime ( T00012_A21EmployeeAddedDate[0] ) )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeAddedDate");
                  GXUtil.WriteLogRaw("Old: ",Z21EmployeeAddedDate);
                  GXUtil.WriteLogRaw("Current: ",T00012_A21EmployeeAddedDate[0]);
               }
               if ( Z7AmusementParkId != T00012_A7AmusementParkId[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"AmusementParkId");
                  GXUtil.WriteLogRaw("Old: ",Z7AmusementParkId);
                  GXUtil.WriteLogRaw("Current: ",T00012_A7AmusementParkId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Employee"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000110 */
                     pr_default.execute(8, new Object[] {A2EmployeeName, A3EmployeeLastName, A4EmployeeAddress, A5EmployeePhone, A6EmployeeEmail, A21EmployeeAddedDate, n7AmusementParkId, A7AmusementParkId});
                     A1EmployeeId = T000110_A1EmployeeId[0];
                     AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000111 */
                     pr_default.execute(9, new Object[] {A2EmployeeName, A3EmployeeLastName, A4EmployeeAddress, A5EmployeePhone, A6EmployeeEmail, A21EmployeeAddedDate, n7AmusementParkId, A7AmusementParkId, A1EmployeeId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Employee");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption010( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000112 */
                  pr_default.execute(10, new Object[] {A1EmployeeId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Employee");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound1 == 0 )
                        {
                           InitAll011( ) ;
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
                        ResetCaption010( ) ;
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000113 */
            pr_default.execute(11, new Object[] {n7AmusementParkId, A7AmusementParkId});
            A8AmusementParkName = T000113_A8AmusementParkName[0];
            AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
            pr_default.close(11);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("employee",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("employee",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Using cursor T000114 */
         pr_default.execute(12);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1EmployeeId = T000114_A1EmployeeId[0];
            AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1EmployeeId = T000114_A1EmployeeId[0];
            AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         edtEmployeeName_Enabled = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Enabled), 5, 0), true);
         edtEmployeeLastName_Enabled = 0;
         AssignProp("", false, edtEmployeeLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeLastName_Enabled), 5, 0), true);
         edtEmployeeAddress_Enabled = 0;
         AssignProp("", false, edtEmployeeAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeAddress_Enabled), 5, 0), true);
         edtEmployeePhone_Enabled = 0;
         AssignProp("", false, edtEmployeePhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeePhone_Enabled), 5, 0), true);
         edtEmployeeEmail_Enabled = 0;
         AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         edtAmusementParkId_Enabled = 0;
         AssignProp("", false, edtAmusementParkId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkId_Enabled), 5, 0), true);
         edtAmusementParkName_Enabled = 0;
         AssignProp("", false, edtAmusementParkName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAmusementParkName_Enabled), 5, 0), true);
         edtEmployeeAddedDate_Enabled = 0;
         AssignProp("", false, edtEmployeeAddedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeAddedDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.AddJavascriptSource("gxcfg.js", "?20236161331596", false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("employee.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EmployeeId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2EmployeeName", StringUtil.RTrim( Z2EmployeeName));
         GxWebStd.gx_hidden_field( context, "Z3EmployeeLastName", StringUtil.RTrim( Z3EmployeeLastName));
         GxWebStd.gx_hidden_field( context, "Z4EmployeeAddress", Z4EmployeeAddress);
         GxWebStd.gx_hidden_field( context, "Z5EmployeePhone", StringUtil.RTrim( Z5EmployeePhone));
         GxWebStd.gx_hidden_field( context, "Z6EmployeeEmail", Z6EmployeeEmail);
         GxWebStd.gx_hidden_field( context, "Z21EmployeeAddedDate", context.localUtil.DToC( Z21EmployeeAddedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z7AmusementParkId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AmusementParkId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
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
         return formatLink("employee.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Employee" ;
      }

      public override string GetPgmdesc( )
      {
         return "Employee" ;
      }

      protected void InitializeNonKey011( )
      {
         A2EmployeeName = "";
         AssignAttri("", false, "A2EmployeeName", A2EmployeeName);
         A3EmployeeLastName = "";
         AssignAttri("", false, "A3EmployeeLastName", A3EmployeeLastName);
         A4EmployeeAddress = "";
         AssignAttri("", false, "A4EmployeeAddress", A4EmployeeAddress);
         A5EmployeePhone = "";
         AssignAttri("", false, "A5EmployeePhone", A5EmployeePhone);
         A6EmployeeEmail = "";
         AssignAttri("", false, "A6EmployeeEmail", A6EmployeeEmail);
         A7AmusementParkId = 0;
         n7AmusementParkId = false;
         AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrimStr( (decimal)(A7AmusementParkId), 4, 0));
         n7AmusementParkId = ((0==A7AmusementParkId) ? true : false);
         A8AmusementParkName = "";
         AssignAttri("", false, "A8AmusementParkName", A8AmusementParkName);
         A21EmployeeAddedDate = Gx_date;
         AssignAttri("", false, "A21EmployeeAddedDate", context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"));
         Z2EmployeeName = "";
         Z3EmployeeLastName = "";
         Z4EmployeeAddress = "";
         Z5EmployeePhone = "";
         Z6EmployeeEmail = "";
         Z21EmployeeAddedDate = DateTime.MinValue;
         Z7AmusementParkId = 0;
      }

      protected void InitAll011( )
      {
         A1EmployeeId = 0;
         AssignAttri("", false, "A1EmployeeId", StringUtil.LTrimStr( (decimal)(A1EmployeeId), 4, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A21EmployeeAddedDate = i21EmployeeAddedDate;
         AssignAttri("", false, "A21EmployeeAddedDate", context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202361613315911", true, true);
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
         context.AddJavascriptSource("employee.js", "?202361613315912", false, true);
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
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME";
         edtEmployeeAddress_Internalname = "EMPLOYEEADDRESS";
         edtEmployeePhone_Internalname = "EMPLOYEEPHONE";
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL";
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID";
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME";
         edtEmployeeAddedDate_Internalname = "EMPLOYEEADDEDDATE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_7_Internalname = "PROMPT_7";
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
         Form.Caption = "Employee";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtEmployeeAddedDate_Jsonclick = "";
         edtEmployeeAddedDate_Enabled = 1;
         edtAmusementParkName_Jsonclick = "";
         edtAmusementParkName_Enabled = 0;
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         edtAmusementParkId_Jsonclick = "";
         edtAmusementParkId_Enabled = 1;
         edtEmployeeEmail_Jsonclick = "";
         edtEmployeeEmail_Enabled = 1;
         edtEmployeePhone_Jsonclick = "";
         edtEmployeePhone_Enabled = 1;
         edtEmployeeAddress_Enabled = 1;
         edtEmployeeLastName_Jsonclick = "";
         edtEmployeeLastName_Enabled = 1;
         edtEmployeeName_Jsonclick = "";
         edtEmployeeName_Enabled = 1;
         edtEmployeeId_Jsonclick = "";
         edtEmployeeId_Enabled = 1;
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
         GX_FocusControl = edtEmployeeName_Internalname;
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

      public void Valid_Employeeid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2EmployeeName", StringUtil.RTrim( A2EmployeeName));
         AssignAttri("", false, "A3EmployeeLastName", StringUtil.RTrim( A3EmployeeLastName));
         AssignAttri("", false, "A4EmployeeAddress", A4EmployeeAddress);
         AssignAttri("", false, "A5EmployeePhone", StringUtil.RTrim( A5EmployeePhone));
         AssignAttri("", false, "A6EmployeeEmail", A6EmployeeEmail);
         AssignAttri("", false, "A7AmusementParkId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")));
         AssignAttri("", false, "A21EmployeeAddedDate", context.localUtil.Format(A21EmployeeAddedDate, "99/99/99"));
         AssignAttri("", false, "A8AmusementParkName", StringUtil.RTrim( A8AmusementParkName));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EmployeeId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2EmployeeName", StringUtil.RTrim( Z2EmployeeName));
         GxWebStd.gx_hidden_field( context, "Z3EmployeeLastName", StringUtil.RTrim( Z3EmployeeLastName));
         GxWebStd.gx_hidden_field( context, "Z4EmployeeAddress", Z4EmployeeAddress);
         GxWebStd.gx_hidden_field( context, "Z5EmployeePhone", StringUtil.RTrim( Z5EmployeePhone));
         GxWebStd.gx_hidden_field( context, "Z6EmployeeEmail", Z6EmployeeEmail);
         GxWebStd.gx_hidden_field( context, "Z7AmusementParkId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AmusementParkId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z21EmployeeAddedDate", context.localUtil.Format(Z21EmployeeAddedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z8AmusementParkName", StringUtil.RTrim( Z8AmusementParkName));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Amusementparkid( )
      {
         n7AmusementParkId = false;
         /* Using cursor T000113 */
         pr_default.execute(11, new Object[] {n7AmusementParkId, A7AmusementParkId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A7AmusementParkId) ) )
            {
               GX_msglist.addItem("No matching 'Amusement Park'.", "ForeignKeyNotFound", 1, "AMUSEMENTPARKID");
               AnyError = 1;
               GX_FocusControl = edtAmusementParkId_Internalname;
            }
         }
         A8AmusementParkName = T000113_A8AmusementParkName[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8AmusementParkName", StringUtil.RTrim( A8AmusementParkName));
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
         setEventMetadata("VALID_EMPLOYEEID","{handler:'Valid_Employeeid',iparms:[{av:'A1EmployeeId',fld:'EMPLOYEEID',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:''},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A21EmployeeAddedDate',fld:'EMPLOYEEADDEDDATE',pic:''}]");
         setEventMetadata("VALID_EMPLOYEEID",",oparms:[{av:'A2EmployeeName',fld:'EMPLOYEENAME',pic:''},{av:'A3EmployeeLastName',fld:'EMPLOYEELASTNAME',pic:''},{av:'A4EmployeeAddress',fld:'EMPLOYEEADDRESS',pic:''},{av:'A5EmployeePhone',fld:'EMPLOYEEPHONE',pic:''},{av:'A6EmployeeEmail',fld:'EMPLOYEEEMAIL',pic:''},{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9'},{av:'A21EmployeeAddedDate',fld:'EMPLOYEEADDEDDATE',pic:''},{av:'A8AmusementParkName',fld:'AMUSEMENTPARKNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1EmployeeId'},{av:'Z2EmployeeName'},{av:'Z3EmployeeLastName'},{av:'Z4EmployeeAddress'},{av:'Z5EmployeePhone'},{av:'Z6EmployeeEmail'},{av:'Z7AmusementParkId'},{av:'Z21EmployeeAddedDate'},{av:'Z8AmusementParkName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_EMPLOYEENAME","{handler:'Valid_Employeename',iparms:[]");
         setEventMetadata("VALID_EMPLOYEENAME",",oparms:[]}");
         setEventMetadata("VALID_EMPLOYEELASTNAME","{handler:'Valid_Employeelastname',iparms:[]");
         setEventMetadata("VALID_EMPLOYEELASTNAME",",oparms:[]}");
         setEventMetadata("VALID_EMPLOYEEPHONE","{handler:'Valid_Employeephone',iparms:[]");
         setEventMetadata("VALID_EMPLOYEEPHONE",",oparms:[]}");
         setEventMetadata("VALID_EMPLOYEEEMAIL","{handler:'Valid_Employeeemail',iparms:[]");
         setEventMetadata("VALID_EMPLOYEEEMAIL",",oparms:[]}");
         setEventMetadata("VALID_AMUSEMENTPARKID","{handler:'Valid_Amusementparkid',iparms:[{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9'},{av:'A8AmusementParkName',fld:'AMUSEMENTPARKNAME',pic:''}]");
         setEventMetadata("VALID_AMUSEMENTPARKID",",oparms:[{av:'A8AmusementParkName',fld:'AMUSEMENTPARKNAME',pic:''}]}");
         setEventMetadata("VALID_EMPLOYEEADDEDDATE","{handler:'Valid_Employeeaddeddate',iparms:[]");
         setEventMetadata("VALID_EMPLOYEEADDEDDATE",",oparms:[]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2EmployeeName = "";
         Z3EmployeeLastName = "";
         Z4EmployeeAddress = "";
         Z5EmployeePhone = "";
         Z6EmployeeEmail = "";
         Z21EmployeeAddedDate = DateTime.MinValue;
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
         A2EmployeeName = "";
         A3EmployeeLastName = "";
         A4EmployeeAddress = "";
         gxphoneLink = "";
         A5EmployeePhone = "";
         A6EmployeeEmail = "";
         sImgUrl = "";
         A8AmusementParkName = "";
         A21EmployeeAddedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         Gx_date = DateTime.MinValue;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z8AmusementParkName = "";
         T00015_A1EmployeeId = new short[1] ;
         T00015_A2EmployeeName = new string[] {""} ;
         T00015_A3EmployeeLastName = new string[] {""} ;
         T00015_A4EmployeeAddress = new string[] {""} ;
         T00015_A5EmployeePhone = new string[] {""} ;
         T00015_A6EmployeeEmail = new string[] {""} ;
         T00015_A8AmusementParkName = new string[] {""} ;
         T00015_A21EmployeeAddedDate = new DateTime[] {DateTime.MinValue} ;
         T00015_A7AmusementParkId = new short[1] ;
         T00015_n7AmusementParkId = new bool[] {false} ;
         T00014_A8AmusementParkName = new string[] {""} ;
         T00016_A8AmusementParkName = new string[] {""} ;
         T00017_A1EmployeeId = new short[1] ;
         T00013_A1EmployeeId = new short[1] ;
         T00013_A2EmployeeName = new string[] {""} ;
         T00013_A3EmployeeLastName = new string[] {""} ;
         T00013_A4EmployeeAddress = new string[] {""} ;
         T00013_A5EmployeePhone = new string[] {""} ;
         T00013_A6EmployeeEmail = new string[] {""} ;
         T00013_A21EmployeeAddedDate = new DateTime[] {DateTime.MinValue} ;
         T00013_A7AmusementParkId = new short[1] ;
         T00013_n7AmusementParkId = new bool[] {false} ;
         sMode1 = "";
         T00018_A1EmployeeId = new short[1] ;
         T00019_A1EmployeeId = new short[1] ;
         T00012_A1EmployeeId = new short[1] ;
         T00012_A2EmployeeName = new string[] {""} ;
         T00012_A3EmployeeLastName = new string[] {""} ;
         T00012_A4EmployeeAddress = new string[] {""} ;
         T00012_A5EmployeePhone = new string[] {""} ;
         T00012_A6EmployeeEmail = new string[] {""} ;
         T00012_A21EmployeeAddedDate = new DateTime[] {DateTime.MinValue} ;
         T00012_A7AmusementParkId = new short[1] ;
         T00012_n7AmusementParkId = new bool[] {false} ;
         T000110_A1EmployeeId = new short[1] ;
         T000113_A8AmusementParkName = new string[] {""} ;
         T000114_A1EmployeeId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i21EmployeeAddedDate = DateTime.MinValue;
         ZZ2EmployeeName = "";
         ZZ3EmployeeLastName = "";
         ZZ4EmployeeAddress = "";
         ZZ5EmployeePhone = "";
         ZZ6EmployeeEmail = "";
         ZZ21EmployeeAddedDate = DateTime.MinValue;
         ZZ8AmusementParkName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employee__default(),
            new Object[][] {
                new Object[] {
               T00012_A1EmployeeId, T00012_A2EmployeeName, T00012_A3EmployeeLastName, T00012_A4EmployeeAddress, T00012_A5EmployeePhone, T00012_A6EmployeeEmail, T00012_A21EmployeeAddedDate, T00012_A7AmusementParkId, T00012_n7AmusementParkId
               }
               , new Object[] {
               T00013_A1EmployeeId, T00013_A2EmployeeName, T00013_A3EmployeeLastName, T00013_A4EmployeeAddress, T00013_A5EmployeePhone, T00013_A6EmployeeEmail, T00013_A21EmployeeAddedDate, T00013_A7AmusementParkId, T00013_n7AmusementParkId
               }
               , new Object[] {
               T00014_A8AmusementParkName
               }
               , new Object[] {
               T00015_A1EmployeeId, T00015_A2EmployeeName, T00015_A3EmployeeLastName, T00015_A4EmployeeAddress, T00015_A5EmployeePhone, T00015_A6EmployeeEmail, T00015_A8AmusementParkName, T00015_A21EmployeeAddedDate, T00015_A7AmusementParkId, T00015_n7AmusementParkId
               }
               , new Object[] {
               T00016_A8AmusementParkName
               }
               , new Object[] {
               T00017_A1EmployeeId
               }
               , new Object[] {
               T00018_A1EmployeeId
               }
               , new Object[] {
               T00019_A1EmployeeId
               }
               , new Object[] {
               T000110_A1EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000113_A8AmusementParkName
               }
               , new Object[] {
               T000114_A1EmployeeId
               }
            }
         );
         Z21EmployeeAddedDate = DateTime.MinValue;
         A21EmployeeAddedDate = DateTime.MinValue;
         i21EmployeeAddedDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short Z1EmployeeId ;
      private short Z7AmusementParkId ;
      private short GxWebError ;
      private short A7AmusementParkId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1EmployeeId ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private short gxajaxcallmode ;
      private short ZZ1EmployeeId ;
      private short ZZ7AmusementParkId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int edtEmployeeLastName_Enabled ;
      private int edtEmployeeAddress_Enabled ;
      private int edtEmployeePhone_Enabled ;
      private int edtEmployeeEmail_Enabled ;
      private int edtAmusementParkId_Enabled ;
      private int imgprompt_7_Visible ;
      private int edtAmusementParkName_Enabled ;
      private int edtEmployeeAddedDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z2EmployeeName ;
      private string Z3EmployeeLastName ;
      private string Z5EmployeePhone ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmployeeId_Internalname ;
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
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeName_Internalname ;
      private string A2EmployeeName ;
      private string edtEmployeeName_Jsonclick ;
      private string edtEmployeeLastName_Internalname ;
      private string A3EmployeeLastName ;
      private string edtEmployeeLastName_Jsonclick ;
      private string edtEmployeeAddress_Internalname ;
      private string edtEmployeePhone_Internalname ;
      private string gxphoneLink ;
      private string A5EmployeePhone ;
      private string edtEmployeePhone_Jsonclick ;
      private string edtEmployeeEmail_Internalname ;
      private string edtEmployeeEmail_Jsonclick ;
      private string edtAmusementParkId_Internalname ;
      private string edtAmusementParkId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_7_Internalname ;
      private string imgprompt_7_Link ;
      private string edtAmusementParkName_Internalname ;
      private string A8AmusementParkName ;
      private string edtAmusementParkName_Jsonclick ;
      private string edtEmployeeAddedDate_Internalname ;
      private string edtEmployeeAddedDate_Jsonclick ;
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
      private string sMode1 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2EmployeeName ;
      private string ZZ3EmployeeLastName ;
      private string ZZ5EmployeePhone ;
      private string ZZ8AmusementParkName ;
      private DateTime Z21EmployeeAddedDate ;
      private DateTime A21EmployeeAddedDate ;
      private DateTime Gx_date ;
      private DateTime i21EmployeeAddedDate ;
      private DateTime ZZ21EmployeeAddedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n7AmusementParkId ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z4EmployeeAddress ;
      private string Z6EmployeeEmail ;
      private string A4EmployeeAddress ;
      private string A6EmployeeEmail ;
      private string ZZ4EmployeeAddress ;
      private string ZZ6EmployeeEmail ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00015_A1EmployeeId ;
      private string[] T00015_A2EmployeeName ;
      private string[] T00015_A3EmployeeLastName ;
      private string[] T00015_A4EmployeeAddress ;
      private string[] T00015_A5EmployeePhone ;
      private string[] T00015_A6EmployeeEmail ;
      private string[] T00015_A8AmusementParkName ;
      private DateTime[] T00015_A21EmployeeAddedDate ;
      private short[] T00015_A7AmusementParkId ;
      private bool[] T00015_n7AmusementParkId ;
      private string[] T00014_A8AmusementParkName ;
      private string[] T00016_A8AmusementParkName ;
      private short[] T00017_A1EmployeeId ;
      private short[] T00013_A1EmployeeId ;
      private string[] T00013_A2EmployeeName ;
      private string[] T00013_A3EmployeeLastName ;
      private string[] T00013_A4EmployeeAddress ;
      private string[] T00013_A5EmployeePhone ;
      private string[] T00013_A6EmployeeEmail ;
      private DateTime[] T00013_A21EmployeeAddedDate ;
      private short[] T00013_A7AmusementParkId ;
      private bool[] T00013_n7AmusementParkId ;
      private short[] T00018_A1EmployeeId ;
      private short[] T00019_A1EmployeeId ;
      private short[] T00012_A1EmployeeId ;
      private string[] T00012_A2EmployeeName ;
      private string[] T00012_A3EmployeeLastName ;
      private string[] T00012_A4EmployeeAddress ;
      private string[] T00012_A5EmployeePhone ;
      private string[] T00012_A6EmployeeEmail ;
      private DateTime[] T00012_A21EmployeeAddedDate ;
      private short[] T00012_A7AmusementParkId ;
      private bool[] T00012_n7AmusementParkId ;
      private short[] T000110_A1EmployeeId ;
      private string[] T000113_A8AmusementParkName ;
      private short[] T000114_A1EmployeeId ;
      private GXWebForm Form ;
   }

   public class employee__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int16,4,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int16,4,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int16,4,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int16,4,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int16,4,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int16,4,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@EmployeeName",GXType.NChar,20,0) ,
          new ParDef("@EmployeeLastName",GXType.NChar,20,0) ,
          new ParDef("@EmployeeAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@EmployeePhone",GXType.NChar,20,0) ,
          new ParDef("@EmployeeEmail",GXType.NVarChar,100,0) ,
          new ParDef("@EmployeeAddedDate",GXType.Date,8,0) ,
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@EmployeeName",GXType.NChar,20,0) ,
          new ParDef("@EmployeeLastName",GXType.NChar,20,0) ,
          new ParDef("@EmployeeAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@EmployeePhone",GXType.NChar,20,0) ,
          new ParDef("@EmployeeEmail",GXType.NVarChar,100,0) ,
          new ParDef("@EmployeeAddedDate",GXType.Date,8,0) ,
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EmployeeId",GXType.Int16,4,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int16,4,0)
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@AmusementParkId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [EmployeeId], [EmployeeName], [EmployeeLastName], [EmployeeAddress], [EmployeePhone], [EmployeeEmail], [EmployeeAddedDate], [AmusementParkId] FROM [Employee] WITH (UPDLOCK) WHERE [EmployeeId] = @EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [EmployeeId], [EmployeeName], [EmployeeLastName], [EmployeeAddress], [EmployeePhone], [EmployeeEmail], [EmployeeAddedDate], [AmusementParkId] FROM [Employee] WHERE [EmployeeId] = @EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT [AmusementParkName] FROM [AmusementPark] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT TM1.[EmployeeId], TM1.[EmployeeName], TM1.[EmployeeLastName], TM1.[EmployeeAddress], TM1.[EmployeePhone], TM1.[EmployeeEmail], T2.[AmusementParkName], TM1.[EmployeeAddedDate], TM1.[AmusementParkId] FROM ([Employee] TM1 LEFT JOIN [AmusementPark] T2 ON T2.[AmusementParkId] = TM1.[AmusementParkId]) WHERE TM1.[EmployeeId] = @EmployeeId ORDER BY TM1.[EmployeeId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT [AmusementParkName] FROM [AmusementPark] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT [EmployeeId] FROM [Employee] WHERE [EmployeeId] = @EmployeeId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT TOP 1 [EmployeeId] FROM [Employee] WHERE ( [EmployeeId] > @EmployeeId) ORDER BY [EmployeeId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00019", "SELECT TOP 1 [EmployeeId] FROM [Employee] WHERE ( [EmployeeId] < @EmployeeId) ORDER BY [EmployeeId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000110", "INSERT INTO [Employee]([EmployeeName], [EmployeeLastName], [EmployeeAddress], [EmployeePhone], [EmployeeEmail], [EmployeeAddedDate], [AmusementParkId]) VALUES(@EmployeeName, @EmployeeLastName, @EmployeeAddress, @EmployeePhone, @EmployeeEmail, @EmployeeAddedDate, @AmusementParkId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "UPDATE [Employee] SET [EmployeeName]=@EmployeeName, [EmployeeLastName]=@EmployeeLastName, [EmployeeAddress]=@EmployeeAddress, [EmployeePhone]=@EmployeePhone, [EmployeeEmail]=@EmployeeEmail, [EmployeeAddedDate]=@EmployeeAddedDate, [AmusementParkId]=@AmusementParkId  WHERE [EmployeeId] = @EmployeeId", GxErrorMask.GX_NOMASK,prmT000111)
             ,new CursorDef("T000112", "DELETE FROM [Employee]  WHERE [EmployeeId] = @EmployeeId", GxErrorMask.GX_NOMASK,prmT000112)
             ,new CursorDef("T000113", "SELECT [AmusementParkName] FROM [AmusementPark] WHERE [AmusementParkId] = @AmusementParkId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000114", "SELECT [EmployeeId] FROM [Employee] ORDER BY [EmployeeId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
