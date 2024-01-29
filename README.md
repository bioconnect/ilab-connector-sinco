README.md

# iLAB Project
## _ilab-sinco_connector_

## 📒 Summary
```
iLAB Sinco Connector는 실험실 내 시험장비/분석장비와 연결된 PC에 설치할 CS 프로그램입니다.
iLAB Sinco Connector는 Base Connector, Trace Connector 2가지 프로그램으로 나뉘어져 있습니다.
iLAB은 Manager, Base, Trace 3가지 모듈로 구성되어 있습니다.

iLAB is a solution for managing data generated in the laboratory of pharmaceutical/bio companies.
iLAB consists of three modules: Manager, Base, and Trace.
The main target companies for iLAB are small domestic pharmaceutical/bio companies.
```
## ✅ 프로그램 소개
#### Base Connector
```
Base Connector 프로그램은 iLAB Base와 연동되는 프로그램이며, 실험장비에서 발생될 레포트와 바이너리 파일을 서버로 업로드합니다.
clawPDF 오픈 소스를 활용하여 가상프린터 기능을 사용할 수 있으며, 대표적인 기능은 다음과 같이 구성되어 있습니다.

  * 시험장비에서 출력한 레포트를 PDF로 변환할 수 있습니다.
  * 시험장비에서 생성한 모든 바이너리 파일들을 스케쥴에 따라 서버로 업로드할 수 있습니다.
  * iLAB Base에서 설정한 권한에 따라 프로젝트 트리에 접근할 수 있습니다.
```

#### Trace Connector
```
Trace Connector 프로그램은 iLAB Trace와 연동되는 프로그램이며, 실험장비에서 생성한 모든 파일을 서버로 업로드합니다. 
CS 프로그램을 통하여 업로드 된 파일들의 Audit 정보를 iLAB Trace에서 확인할 수 있으며, 대표적인 기능으로 다음과 같이 구성되어 있습니다.

  * 스케쥴을 설정하여 지정된 폴더 하위의 모든 구조와 파일을 서버로 업로드합니다.
  * 업로드된 파일들의 전송 주체, 전송자, 전송 장비, 전송 시점 등 Audit 과 관련된 정보를 확인할 수 있습니다.
```

## ⚙️ Base Connector 설치 가이드 (최초)
```
1. source download
2. ilab-connector-sinco\clawPDF\_Build.zip 압축해제
3. 프로젝트 실행
4. BASE.Connector-1.0.0.msi 빌드
5. 파일 탐색기에서 폴더 열기
6. Debug\BASE.COnnector-1.0.0.msi 설치
```


## 📌 관련 문서
```
\02. 실험실솔루션 제품\iLAB\iLAB_sinco\iLAB개발자료
```

 ## 🛠 Tech Stack
 <p>
<img src="https://img.shields.io/badge/.NET-0769AD?style=for-the-badge&logo=.NET&logoColor=white"></a> &nbsp 
<img src="https://img.shields.io/badge/Csharp-E4E4E4?style=for-the-badge&logo=Csharp&logoColor=red"/></a> &nbsp
<img src="https://img.shields.io/badge/apache tomcat-F8DC75?style=for-the-badge&logo=apachetomcat&logoColor=white"> &nbsp
<img src="https://img.shields.io/badge/MariaDb-339933?style=for-the-badge&logo=MariaDb&logoColor=white"/></a> &nbsp
<img src="https://img.shields.io/badge/SQLite-4479A1?style=for-the-badge&logo=SQLite&logoColor=white"/></a> &nbsp 
</p>
