gx.evt.autoSkip=!1;gx.define("technician",!1,function(){this.ServerClass="technician";this.PackageName="GeneXus.Programs";this.ServerFullClass="technician.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Technicianid=function(){return this.validSrvEvt("Valid_Technicianid",0).then(function(n){return n}.closure(this))};this.e11078_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e12078_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48];this.GXLastCtrlId=48;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e13078_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e14078_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e15078_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e16078_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e17078_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Technicianid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TECHNICIANID",gxz:"Z27TechnicianId",gxold:"O27TechnicianId",gxvar:"A27TechnicianId",ucs:[],op:[39],ip:[39,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A27TechnicianId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27TechnicianId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TECHNICIANID",gx.O.A27TechnicianId,0)},c2v:function(){this.val()!==undefined&&(gx.O.A27TechnicianId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TECHNICIANID",",")},nac:gx.falseFn};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TECHNICIANNAME",gxz:"Z28TechnicianName",gxold:"O28TechnicianName",gxvar:"A28TechnicianName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A28TechnicianName=n)},v2z:function(n){n!==undefined&&(gx.O.Z28TechnicianName=n)},v2c:function(){gx.fn.setControlValue("TECHNICIANNAME",gx.O.A28TechnicianName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A28TechnicianName=this.val())},val:function(){return gx.fn.getControlValue("TECHNICIANNAME")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"BTN_ENTER",grid:0,evt:"e11078_client",std:"ENTER"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"BTN_CANCEL",grid:0,evt:"e12078_client"};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"BTN_DELETE",grid:0,evt:"e18078_client",std:"DELETE"};this.A27TechnicianId=0;this.Z27TechnicianId=0;this.O27TechnicianId=0;this.A28TechnicianName="";this.Z28TechnicianName="";this.O28TechnicianName="";this.A27TechnicianId=0;this.A28TechnicianName="";this.Events={e11078_client:["ENTER",!0],e12078_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0}],[]];this.EvtParms.REFRESH=[[],[]];this.EvtParms.VALID_TECHNICIANID=[[{av:"A27TechnicianId",fld:"TECHNICIANID",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!"}],[{av:"A28TechnicianName",fld:"TECHNICIANNAME",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!"},{av:"Z27TechnicianId"},{av:"Z28TechnicianName"},{ctrl:"BTN_DELETE",prop:"Enabled"},{ctrl:"BTN_ENTER",prop:"Enabled"}]];this.EnterCtrl=["BTN_ENTER"];this.Initialize()});gx.wi(function(){gx.createParentObj(this.technician)})