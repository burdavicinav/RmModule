

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0628 */
/* at Tue Jan 19 07:14:07 2038
 */
/* Compiler settings for RmModule.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 8.01.0628 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 500
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __RmModule_i_h__
#define __RmModule_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

#ifndef DECLSPEC_XFGVIRT
#if defined(_CONTROL_FLOW_GUARD_XFG)
#define DECLSPEC_XFGVIRT(base, func) __declspec(xfg_virtual(base, func))
#else
#define DECLSPEC_XFGVIRT(base, func)
#endif
#endif

/* Forward Declarations */ 

#ifndef __IOmpTask_FWD_DEFINED__
#define __IOmpTask_FWD_DEFINED__
typedef interface IOmpTask IOmpTask;

#endif 	/* __IOmpTask_FWD_DEFINED__ */


#ifndef __ApplicationOnResourceReport_FWD_DEFINED__
#define __ApplicationOnResourceReport_FWD_DEFINED__

#ifdef __cplusplus
typedef class ApplicationOnResourceReport ApplicationOnResourceReport;
#else
typedef struct ApplicationOnResourceReport ApplicationOnResourceReport;
#endif /* __cplusplus */

#endif 	/* __ApplicationOnResourceReport_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "shobjidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IOmpTask_INTERFACE_DEFINED__
#define __IOmpTask_INTERFACE_DEFINED__

/* interface IOmpTask */
/* [object][unique][uuid] */ 


EXTERN_C const IID IID_IOmpTask;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("15D2A7B2-9C3D-11d2-B5D0-0000E84F2903")
    IOmpTask : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Run( 
            /* [in] */ HWND parent,
            /* [out] */ HWND *created_wnd,
            /* [out] */ long *error_code) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IOmpTaskVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IOmpTask * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IOmpTask * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IOmpTask * This);
        
        DECLSPEC_XFGVIRT(IOmpTask, Run)
        HRESULT ( STDMETHODCALLTYPE *Run )( 
            IOmpTask * This,
            /* [in] */ HWND parent,
            /* [out] */ HWND *created_wnd,
            /* [out] */ long *error_code);
        
        END_INTERFACE
    } IOmpTaskVtbl;

    interface IOmpTask
    {
        CONST_VTBL struct IOmpTaskVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IOmpTask_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IOmpTask_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IOmpTask_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IOmpTask_Run(This,parent,created_wnd,error_code)	\
    ( (This)->lpVtbl -> Run(This,parent,created_wnd,error_code) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IOmpTask_INTERFACE_DEFINED__ */



#ifndef __RmModuleLib_LIBRARY_DEFINED__
#define __RmModuleLib_LIBRARY_DEFINED__

/* library RmModuleLib */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_RmModuleLib;

EXTERN_C const CLSID CLSID_ApplicationOnResourceReport;

#ifdef __cplusplus

class DECLSPEC_UUID("e0f694af-faba-48dc-94a5-c7f484d10b97")
ApplicationOnResourceReport;
#endif
#endif /* __RmModuleLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  HWND_UserSize(     unsigned long *, unsigned long            , HWND * ); 
unsigned char * __RPC_USER  HWND_UserMarshal(  unsigned long *, unsigned char *, HWND * ); 
unsigned char * __RPC_USER  HWND_UserUnmarshal(unsigned long *, unsigned char *, HWND * ); 
void                      __RPC_USER  HWND_UserFree(     unsigned long *, HWND * ); 

unsigned long             __RPC_USER  HWND_UserSize64(     unsigned long *, unsigned long            , HWND * ); 
unsigned char * __RPC_USER  HWND_UserMarshal64(  unsigned long *, unsigned char *, HWND * ); 
unsigned char * __RPC_USER  HWND_UserUnmarshal64(unsigned long *, unsigned char *, HWND * ); 
void                      __RPC_USER  HWND_UserFree64(     unsigned long *, HWND * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


