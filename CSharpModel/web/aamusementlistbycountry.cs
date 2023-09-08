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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aamusementlistbycountry : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public aamusementlistbycountry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aamusementlistbycountry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         aamusementlistbycountry objaamusementlistbycountry;
         objaamusementlistbycountry = new aamusementlistbycountry();
         objaamusementlistbycountry.context.SetSubmitInitialConfig(context);
         objaamusementlistbycountry.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaamusementlistbycountry);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aamusementlistbycountry)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0G0( false, 131) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 205, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Amusement Park by Country", 350, Gx_line+50, 667, Gx_line+83, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "65b389d6-6e76-4dc6-ac43-ab05d29b2c3f", "", context.GetTheme( )), 242, Gx_line+17, 325, Gx_line+100) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+131);
            H0G0( false, 77) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Country Name", 442, Gx_line+33, 513, Gx_line+50, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Id", 225, Gx_line+33, 235, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Name", 283, Gx_line+33, 316, Gx_line+47, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Photo", 642, Gx_line+33, 672, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(225, Gx_line+67, 683, Gx_line+67, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+77);
            /* Using cursor P000G2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A12CountryId = P000G2_A12CountryId[0];
               A13CountryName = P000G2_A13CountryName[0];
               A40000AmusementParkPhoto_GXI = P000G2_A40000AmusementParkPhoto_GXI[0];
               A8AmusementParkName = P000G2_A8AmusementParkName[0];
               A7AmusementParkId = P000G2_A7AmusementParkId[0];
               A11AmusementParkPhoto = P000G2_A11AmusementParkPhoto[0];
               A13CountryName = P000G2_A13CountryName[0];
               H0G0( false, 135) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9")), 225, Gx_line+17, 251, Gx_line+32, 2+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : A11AmusementParkPhoto);
               getPrinter().GxDrawBitMap(sImgUrl, 608, Gx_line+17, 690, Gx_line+100) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8AmusementParkName, "")), 283, Gx_line+17, 383, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13CountryName, "")), 442, Gx_line+17, 575, Gx_line+32, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+135);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0G0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0G0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000G2_A12CountryId = new short[1] ;
         P000G2_A13CountryName = new string[] {""} ;
         P000G2_A40000AmusementParkPhoto_GXI = new string[] {""} ;
         P000G2_A8AmusementParkName = new string[] {""} ;
         P000G2_A7AmusementParkId = new short[1] ;
         P000G2_A11AmusementParkPhoto = new string[] {""} ;
         A13CountryName = "";
         A40000AmusementParkPhoto_GXI = "";
         A8AmusementParkName = "";
         A11AmusementParkPhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aamusementlistbycountry__default(),
            new Object[][] {
                new Object[] {
               P000G2_A12CountryId, P000G2_A13CountryName, P000G2_A40000AmusementParkPhoto_GXI, P000G2_A8AmusementParkName, P000G2_A7AmusementParkId, P000G2_A11AmusementParkPhoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A12CountryId ;
      private short A7AmusementParkId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A13CountryName ;
      private string A8AmusementParkName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40000AmusementParkPhoto_GXI ;
      private string A11AmusementParkPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_A12CountryId ;
      private string[] P000G2_A13CountryName ;
      private string[] P000G2_A40000AmusementParkPhoto_GXI ;
      private string[] P000G2_A8AmusementParkName ;
      private short[] P000G2_A7AmusementParkId ;
      private string[] P000G2_A11AmusementParkPhoto ;
   }

   public class aamusementlistbycountry__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT T1.[CountryId], T2.[CountryName], T1.[AmusementParkPhoto_GXI], T1.[AmusementParkName], T1.[AmusementParkId], T1.[AmusementParkPhoto] FROM ([AmusementPark] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) WHERE T2.[CountryName] = 'Indonesia' ORDER BY T1.[AmusementParkId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
       }
    }

 }

}
