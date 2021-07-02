<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDance.aspx.cs" Inherits="DanceProject.Pages.AddDance" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
#bg {
  position: fixed; 
  top: 0; 
  left: 0; 
	
  /* Preserve aspet ratio */
  width: 100%;
  height: 100%;
  z-index:-1;
}
.val
{
Display:Dynamic;
}


.btn
{
  background-color: white;
  color: black;
  border: 1px solid #555555;
  border-radius: 4px;
}
.btn:hover {
  background-color: #555555;
  color: white;
}

#Panel1
{
    position:absolute;
    width:400px;
    height:380px;
    left:450px;
    top:134px;
    background-color:rgba(255,255,255,0.5);
    border-color:#555555;
    border-width:2px;
    border-radius:4px;
    border-style:solid;
}
        #Image1
        {
            position:absolute;
            left:320px;
        }

#Menu1
        {
            position:absolute;
            top:14px;
            left:0px;
        }
                #Menu2
        {
            position:absolute;
            top:14px;
            left:0px;
        }
                
        #Menu3
        {
            position:absolute;
            top:14px;
            left:0px;
        }
#ImageButton1
{
    position:absolute;
    top:14px;
    left:1225px;
            height: 64px;
            width: 70px;
            right: -23px;
        }

        #ImageButton2
        {
            position:absolute;
            top:27px;
            left:1102px;
            right: 229px;
            z-index:5;
        }
        
        #ImageButton3
        {
            position:absolute;
            top:24px;
            left:1156px;
            height: 42px;
            width: 43px;
        }
                #ImageButton5
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
        }
        
        #DanceVideo
        {
            position:absolute;
            left:98px;
        }
        
                #Hi
        {
            position:absolute;
            top:70px;
            left:1093px;
            z-index:5;
            text-align: center;
            width: 170px;
        }

</style>
    
</head>
<body style="text-align: center; font-family: Tahoma">

    <form id="form1" runat="server">
    <img src="/Photos/Background.png" id="bg" alt="">
    <asp:Label ID="Hi" runat="server" Text="hi"></asp:Label>
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" >
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddDance.aspx" Text="Add a new dance" 
                        Value="Add a new dance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddPerformance.aspx" Text="Add a new performance" 
                        Value="Add a new performance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Admin" Value="Admin">
                    <asp:MenuItem NavigateUrl="BlockedUsers.aspx" 
                        Text="Show blocked users and new activities" 
                        Value="Show blocked users and new activities"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Catagories.aspx" Text="Show categories" 
                        Value="Show categories"></asp:MenuItem>
                        </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="/Photos/NotificationIcon.png" Height="35px" ToolTip="Notifications" 
            Width="35px" onclick="ImageButton2_Click" CausesValidation="False" />

            <asp:Menu ID="Menu2" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" >
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddDance.aspx" Text="Add a new dance" 
                        Value="Add a new dance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddPerformance.aspx" Text="Add a new performance" 
                        Value="Add a new performance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

       <asp:Menu ID="Menu3" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px">
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
<StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Photos/Logo.png"
            onclick="ImageButton1_Click" ToolTip="Home page" 
        CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
        onclick="ImageButton3_Click" CausesValidation="False" />
    <div>
        <br />
        <br />
        <br />
        <br />
        &nbsp;<asp:Panel ID="Panel1" runat="server">
            <br />
            <asp:TextBox ID="DanceName" runat="server" Placeholder="Dance name" 
                Width="200px"  ></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                class="val" ControlToValidate="DanceName" 
                ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="DanceSong" runat="server" Placeholder="Dance song" 
                Width="200px"></asp:TextBox>
            <br />
            <strong>
            <br />
            Dance Style:</strong><br />
            <asp:DropDownList ID="DanceStyle" runat="server" Width="200px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:TextBox ID="DanceVideo" runat="server" Placeholder="Dance video" 
                Width="200px" ></asp:TextBox>
            <asp:Image ID="Image1" runat="server" Height="30px" ImageUrl="/Photos/Help.png" 
                ToolTip="Upload the video to YouTube. Press 'Share'-&gt;'Embed'. Copy the link and paste it here." 
                Width="30px" />
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" style="font-weight: 700" 
                Text="Dance Photo: "></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" class="btn" Width="200px" />
            <br />
            <br />
            <asp:TextBox ID="DanceLength" runat="server" Placeholder="Dance length" 
                Width="200px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                class="val" ControlToValidate="DanceLength" 
                ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                class="val" ControlToValidate="DanceLength" 
                ErrorMessage="Dance length must be a double number" 
                ValidationExpression="\d+\.\d+"></asp:RegularExpressionValidator>
            <br />
            <asp:ImageButton ID="ImageButton4" runat="server" Height="50px" 
                ImageUrl="/Photos/NextIcon.png" onclick="ImageButton4_Click" Text="Next" 
                Width="50px" />
            <br />
            <br />
            <asp:Label ID="Label9" runat="server"></asp:Label>
        </asp:Panel>
        <br />
    </div>
    <asp:ImageButton ID="ImageButton5" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton5_Click" 
        ToolTip="Log out" CausesValidation="False" />
    </form>
</body>
</html>
