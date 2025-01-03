#pragma once
#ifndef __CPPDLL_H__
#define __CPPDLL_H__
#define _EXTERN_C_ extern "C" __declspec(dllexport)
#include <string>
#include<istream>
#include<Windows.h>
struct SystemTime{
	int year;
	int month;
	int day;
	int hour;
	int minute;
	int second;
	int millsecond;
	SystemTime& operator=(SystemTime st) {
		this ->year = st.year;
		this ->month = st.month;
		this ->day = st.day;
		this ->hour = st.hour;
		this ->minute = st.minute;
		this ->second = st.second;
		this ->millsecond = st.millsecond;
		return  * this ;
	}
};
//定义一个函数指针
typedef void (__stdcall* CPPCallback)(int tick);
CPPCallback callbackGlobal;
DWORD WINAPI Function(LPVOID lpParamter);//Windows API创建线程的函数
//设置函数指针，调用C#传递过来的委托
_EXTERN_C_ void SetCallback(CPPCallback callback);
_EXTERN_C_ int Add(int x, int y);
_EXTERN_C_ int TestChar(char* src, char* res, int nCount);
_EXTERN_C_ int TestStruct(SystemTime& stSrc, SystemTime& stRes);
_EXTERN_C_ void WriteString(wchar_t* content);

_EXTERN_C_ void  AddInt(int* i);
//传入一个整型数组的指针以及数组长度，遍历每一个元素并且输出
_EXTERN_C_ void PrintArrayThroughCPP(int* first, int length);
//在C++中生成一个整型数组，并且数组指针返回给C#
_EXTERN_C_ int* GetArrayFromCPP();

_EXTERN_C_ void SayHello(char* name);

//定义一个接受函数指针的函数，接受并调用函数指针，导出注册函数
extern "C" typedef int(*CallBack)(int, int);
_EXTERN_C_ void RegisterCallback(CallBack cb);

//C++向C#传递函数指针，导出函数指针
extern "C" int Sub(int x, int y) { return x - y; }
_EXTERN_C_ int(*GetFuncPtr())(int, int);

//导出类
class __declspec(dllexport)  TestClass {
public :
	TestClass() {};
	int Sub(int x, int y) { return x - y; }
};


#endif // !__CPPDLL_H__
