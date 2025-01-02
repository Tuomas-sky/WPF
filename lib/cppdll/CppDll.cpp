#include "pch.h"
#include "CppDll.h"
#include <stdio.h>
#include <time.h>
#include <iostream>
using namespace std;

DWORD WINAPI Function(LPVOID lpParamter)
{
	//该线程每隔一秒向C#发送一个0到99之间的数字，并让C#处理该数据。
	cout << "A Thread Function Display!" << endl;
	srand((int)time(0));//随机种子
	for (int i = 0; i < 10; i++)
	{
		callbackGlobal(rand() % 100);
		Sleep(1000);
	}
	return 0L;
}

void SetCallback(CPPCallback callback)
{
	//从C#来的回调对象callback赋值给本地全局函数指针对象callbackGlobal
	callbackGlobal = callback;
	//创建线程
	HANDLE hThread = CreateThread(NULL, 0, Function, NULL, 0, NULL);
	CloseHandle(hThread);
}

int  Add(int  x, int  y)
{
	return  x + y;
}

int TestChar(char* src, char* res, int nCount)
{
	memcpy(res, src, sizeof(char) * nCount);
	return 1;
}

int TestStruct(SystemTime& stSrc, SystemTime& stRes)
{
	stRes = stSrc;
	return 1;
}

void WriteString(wchar_t* content)
{
	//第一次调用确认转换后单字节字符串的长度，用于开辟空间
	int pSize = WideCharToMultiByte(CP_OEMCP, 0, content,wcslen(content), NULL, 0, NULL, NULL);
	char* pCStrKey = new char[pSize+1];
	//第二次调用将双字节字符串转换成单字节字符串
	WideCharToMultiByte(CP_OEMCP,0, content, wcslen(content), pCStrKey, pSize, NULL, NULL);
	pCStrKey[pSize] = '\0';
	cout << pCStrKey << endl;
	//如果想要转换成string，直接赋值即可
	//string pKey = pCStrKey;
}
void  AddInt(int* i)
{
	(*i)++;
}
void  PrintArrayThroughCPP(int* firstElement, int arrayLength)
{
	int* currentPointer = firstElement;
	for (int i = 0; i < arrayLength; i++)
	{
		cout << *currentPointer;
		currentPointer++;
	}
	cout << endl;
}

int* GetArrayFromCPP()
{
	int* arrPtr = new int[10];
	for (int i = 0; i < 10; i++)
	{
		arrPtr[i] = i + 1;
	}
	return arrPtr;
}
