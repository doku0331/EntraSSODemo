# EntraID SSO Demo
這是一個專案用以展示EntraID 是如何跟.net 界接

控制介面:
- https://entra.microsoft.com/

# 註冊應用程式
前往 https://entra.microsoft.com  
選擇你的租用戶 (Tenant)  (右上角切換目錄)
左側選單點選「應用程式」→「應用程式註冊」  

填入以下資料：
名稱、重新導向 URI、驗證範圍
這裡的URI可以輸入Localhost (跟SMAL最大的不同)

去Authentication的選項
勾選 ID tokens (used for implicit and hybrid flows)


# 取得資訊
ClientId、TenantId、密鑰

左邊的憑證與密碼=> 用戶端密碼
值的部分只顯示一次 關掉就不顯示了 請注意

# 安裝必要套件
dotnet add package Microsoft.AspNetCore.Authentication.OpenIdConnect
dotnet add package Microsoft.Identity.Web
dotnet add package Microsoft.Identity.Web.UI

安裝完可用
dotnet package list --project .\EntraSSODemo.csproj 檢查一下

# 裝填一下config
``` xml
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    // 這下面的都可以在剛剛的流程找到
    "Domain": "yourdomain.onmicrosoft.com",
    "TenantId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "ClientId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
    "ClientSecret": "your-client-secret",
    "CallbackPath": "/signin-oidc"
  }
```
修改程式後就可以看能不能登入

# 登入登出與me
安裝 套件
dotnet add package Microsoft.Graph
dotnet add package Microsoft.Identity.Web.GraphServiceClient --version 3.9.4
修改程式就可以看能不能登出與取得me


