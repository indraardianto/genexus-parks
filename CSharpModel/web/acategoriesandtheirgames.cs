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
   public class acategoriesandtheirgames : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public acategoriesandtheirgames( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acategoriesandtheirgames( IGxContext context )
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
         acategoriesandtheirgames objacategoriesandtheirgames;
         objacategoriesandtheirgames = new acategoriesandtheirgames();
         objacategoriesandtheirgames.context.SetSubmitInitialConfig(context);
         objacategoriesandtheirgames.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objacategoriesandtheirgames);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acategoriesandtheirgames)stateInfo).executePrivate();
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
            H0H0( false, 137) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "d4d7688f-9e48-47ed-8664-8ef95772c471", "", context.GetTheme( )), 75, Gx_line+17, 333, Gx_line+117) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Categories And Their Games", 375, Gx_line+67, 692, Gx_line+100, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+137);
            /* Using cursor P000H2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0H2 = false;
               A7AmusementParkId = P000H2_A7AmusementParkId[0];
               A14CategoryId = P000H2_A14CategoryId[0];
               n14CategoryId = P000H2_n14CategoryId[0];
               A40000GamePhoto_GXI = P000H2_A40000GamePhoto_GXI[0];
               A8AmusementParkName = P000H2_A8AmusementParkName[0];
               A17GameName = P000H2_A17GameName[0];
               A15CategoryName = P000H2_A15CategoryName[0];
               A16GameId = P000H2_A16GameId[0];
               A18GamePhoto = P000H2_A18GamePhoto[0];
               A8AmusementParkName = P000H2_A8AmusementParkName[0];
               A15CategoryName = P000H2_A15CategoryName[0];
               H0H0( false, 46) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, true, false, false, false, 0, 255, 165, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Category :", 75, Gx_line+17, 150, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A15CategoryName, "")), 158, Gx_line+17, 419, Gx_line+34, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+46);
               H0H0( false, 90) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Games", 75, Gx_line+17, 110, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Name", 150, Gx_line+50, 180, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Park Name", 333, Gx_line+50, 389, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Photo", 625, Gx_line+50, 655, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(133, Gx_line+83, 691, Gx_line+83, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+90);
               while ( (pr_default.getStatus(0) != 101) && ( P000H2_A14CategoryId[0] == A14CategoryId ) )
               {
                  BRK0H2 = false;
                  A7AmusementParkId = P000H2_A7AmusementParkId[0];
                  A40000GamePhoto_GXI = P000H2_A40000GamePhoto_GXI[0];
                  A8AmusementParkName = P000H2_A8AmusementParkName[0];
                  A17GameName = P000H2_A17GameName[0];
                  A16GameId = P000H2_A16GameId[0];
                  A18GamePhoto = P000H2_A18GamePhoto[0];
                  A8AmusementParkName = P000H2_A8AmusementParkName[0];
                  H0H0( false, 126) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A17GameName, "")), 142, Gx_line+17, 259, Gx_line+32, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A18GamePhoto)) ? A40000GamePhoto_GXI : A18GamePhoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 583, Gx_line+17, 691, Gx_line+100) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8AmusementParkName, "")), 325, Gx_line+17, 500, Gx_line+32, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+126);
                  BRK0H2 = true;
                  pr_default.readNext(0);
               }
               if ( ! BRK0H2 )
               {
                  BRK0H2 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0H0( true, 0) ;
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

      protected void H0H0( bool bFoot ,
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
         P000H2_A7AmusementParkId = new short[1] ;
         P000H2_A14CategoryId = new short[1] ;
         P000H2_n14CategoryId = new bool[] {false} ;
         P000H2_A40000GamePhoto_GXI = new string[] {""} ;
         P000H2_A8AmusementParkName = new string[] {""} ;
         P000H2_A17GameName = new string[] {""} ;
         P000H2_A15CategoryName = new string[] {""} ;
         P000H2_A16GameId = new short[1] ;
         P000H2_A18GamePhoto = new string[] {""} ;
         A40000GamePhoto_GXI = "";
         A8AmusementParkName = "";
         A17GameName = "";
         A15CategoryName = "";
         A18GamePhoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acategoriesandtheirgames__default(),
            new Object[][] {
                new Object[] {
               P000H2_A7AmusementParkId, P000H2_A14CategoryId, P000H2_n14CategoryId, P000H2_A40000GamePhoto_GXI, P000H2_A8AmusementParkName, P000H2_A17GameName, P000H2_A15CategoryName, P000H2_A16GameId, P000H2_A18GamePhoto
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
      private short A7AmusementParkId ;
      private short A14CategoryId ;
      private short A16GameId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A8AmusementParkName ;
      private string A17GameName ;
      private string A15CategoryName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK0H2 ;
      private bool n14CategoryId ;
      private string A40000GamePhoto_GXI ;
      private string A18GamePhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000H2_A7AmusementParkId ;
      private short[] P000H2_A14CategoryId ;
      private bool[] P000H2_n14CategoryId ;
      private string[] P000H2_A40000GamePhoto_GXI ;
      private string[] P000H2_A8AmusementParkName ;
      private string[] P000H2_A17GameName ;
      private string[] P000H2_A15CategoryName ;
      private short[] P000H2_A16GameId ;
      private string[] P000H2_A18GamePhoto ;
   }

   public class acategoriesandtheirgames__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT T1.[AmusementParkId], T1.[CategoryId], T1.[GamePhoto_GXI], T2.[AmusementParkName], T1.[GameName], T3.[CategoryName], T1.[GameId], T1.[GamePhoto] FROM (([Game] T1 INNER JOIN [AmusementPark] T2 ON T2.[AmusementParkId] = T1.[AmusementParkId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) ORDER BY T1.[CategoryId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                ((string[]) buf[6])[0] = rslt.getString(6, 50);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
       }
    }

 }

}
