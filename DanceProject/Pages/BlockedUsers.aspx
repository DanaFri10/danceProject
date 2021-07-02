<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlockedUsers.aspx.cs" Inherits="DanceProject.Pages.BlockedUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body  
        {
background-color:#fae4e0;

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
            z-index:5;
        }
        .grids
        {background-color:rgba(255,255,255,0.5);
        }
        
                        #ImageButton5
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
            z-index:5;
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
<body style="text-align: left; font-family: Tahoma">
    <form id="form1" runat="server">
    <p>
    <asp:Label ID="Hi" runat="server" Text="hi"></asp:Label>
    <asp:ImageButton ID="ImageButton5" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton5_Click" 
        ToolTip="Log out" CausesValidation="False" />
    </p>
    <div>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px">
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

        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="/Photos/NotificationIcon.png" Height="35px" ToolTip="Notifications" 
            Width="35px" onclick="ImageButton2_Click" CausesValidation="False" />

            <asp:Menu ID="Menu3" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" 
            >
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
            onclick="ImageButton1_Click" ToolTip="Home page" CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
            onclick="ImageButton3_Click" CausesValidation="False" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Blocked users: " 
            style="font-family: Tahoma; font-weight: 700;" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Find user by id" 
            Width="200px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton6" runat="server" 
            ImageUrl="/Photos/SearchIcon.png" Height="20px" Width="20px" 
            onclick="ImageButton6_Click"/>
        &nbsp;<asp:TextBox ID="TextBox2" runat="server" placeholder="Find user by name" 
            Width="200px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton7" runat="server" 
            ImageUrl="/Photos/SearchIcon.png" Height="20px" onclick="ImageButton7_Click" 
            Width="20px"/>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" class="grids" 
            style="font-family: Tahoma; text-align: center;" 
            onrowcommand="GridView2_RowCommand">
        <Columns>
        <asp:BoundField DataField="UserId" HeaderText="User Id" />
        <asp:BoundField DataField="UserCategory" HeaderText="User Category" />
        <asp:BoundField DataField="UserFirstName" HeaderText="First Name" />
        <asp:BoundField DataField="UserLastName" HeaderText="Last Name" />
        <asp:BoundField DataField="UserBirthDate" HeaderText="Birth Date" />
            <asp:ImageField DataImageUrlField="ProfilePicture" HeaderText="Profile Picture">
                <ControlStyle Height="50px" Width="50px" />
                <ItemStyle Height="50px" Width="50px" />
            </asp:ImageField>
        <asp:BoundField DataField="UserPhoneNumber" HeaderText="Phone Number" />
            <asp:ButtonField ButtonType="Button" CommandName="Unblock" HeaderText="Unblock" 
                ShowHeader="True" Text="Unblock" />
        </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label5" runat="server" 
            style="font-weight: 700; font-family: Tahoma" Text="New users:" 
            Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" placeholder="Find user by id" 
            Width="200px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton8" runat="server" 
            ImageUrl="/Photos/SearchIcon.png" Height="20px" Width="20px" 
            onclick="ImageButton8_Click"/>
        &nbsp;<asp:TextBox ID="TextBox4" runat="server" placeholder="Find user by name" 
            Width="200px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton9" runat="server" 
            ImageUrl="/Photos/SearchIcon.png" Height="20px" onclick="ImageButton9_Click" 
            Width="20px"/>
        <asp:GridView ID="GridView3" runat="server" style="font-family: Tahoma; text-align: center;" class="grids" 
            AutoGenerateColumns="False" onrowcommand="GridView3_RowCommand">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="User Id" 
                    SortExpression="UserId" />
                <asp:BoundField DataField="UserCategory" HeaderText="User Category" 
                    SortExpression="UserCategory" />
                <asp:BoundField DataField="UserFirstName" HeaderText="First Name" 
                    SortExpression="UserFirstName" />
                <asp:BoundField DataField="UserLastName" HeaderText="Last Name" 
                    SortExpression="UserLastName" />
                <asp:BoundField DataField="UserBirthDate" HeaderText="Birth Date" 
                    SortExpression="UserBirthDate" />
                <asp:ImageField DataImageUrlField="ProfilePicture" HeaderText="Profile Picture">
                    <ControlStyle Height="50px" Width="50px" />
                    <ItemStyle Height="50px" Width="50px" />
                </asp:ImageField>
                <asp:BoundField DataField="UserPhoneNumber" HeaderText="Phone Number" 
                    SortExpression="UserPhoneNumber" />
                <asp:ButtonField ButtonType="Button" CommandName="Confirm" HeaderText="Confirm" 
                    ShowHeader="True" Text="Confirm" />
                <asp:ButtonField ButtonType="Button" CommandName="Block" HeaderText="Block" 
                    ShowHeader="True" Text="Block" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label6" runat="server" 
            style="font-weight: 700; font-family: Tahoma" Text="New dances:" 
            Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox5" runat="server" placeholder="Find dance by id" 
            Width="200px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton10" runat="server" 
            ImageUrl="/Photos/SearchIcon.png" Height="20px" Width="20px" 
            onclick="ImageButton10_Click"/>
        &nbsp;<asp:TextBox ID="TextBox6" runat="server" placeholder="Find dance by name" 
            Width="200px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton11" runat="server" 
            ImageUrl="/Photos/SearchIcon.png" Height="20px" onclick="ImageButton11_Click" 
            Width="20px"/>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" class="grids"
            onrowcommand="GridView4_RowCommand" style="font-family: Tahoma; text-align: center;" 
            onrowdeleting="GridView4_RowDeleting">
            <Columns>
                <asp:BoundField DataField="DanceId" HeaderText="Dance Id" 
                    SortExpression="DanceId" />
                <asp:BoundField DataField="DanceName" HeaderText="Dance Name" 
                    SortExpression="DanceName" />
                <asp:BoundField DataField="DanceStyle" 
                    HeaderText="Dance Style" SortExpression="DanceStyle" />
                <asp:BoundField DataField="DanceType" 
                    HeaderText="Dance Type" SortExpression="DanceType" />
                <asp:BoundField DataField="ChoreographerName" HeaderText="Choreographer Name" 
                    SortExpression="ChoreographerName" />
                <asp:BoundField DataField="DanceVideo" HeaderText="Dance Video" 
                    SortExpression="DanceVideo" />
                <asp:BoundField DataField="DanceLength" HeaderText="Dance Length" 
                    SortExpression="DanceLength" />
                <asp:ImageField DataImageUrlField="DancePhoto" HeaderText="Dance Photo">
                    <ControlStyle Height="50px" Width="50px" />
                    <ItemStyle Height="50px" Width="50px" />
                </asp:ImageField>
                <asp:ButtonField ButtonType="Button" CommandName="Confirm" HeaderText="Confirm" 
                    ShowHeader="True" Text="Confirm" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" 
                    ShowHeader="True" Text="Delete" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label7" runat="server" 
            style="font-family: Tahoma; font-weight: 700" Text="New Performances:" 
            Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox7" runat="server" placeholder="Find performance by id" 
            Width="200px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton12" runat="server" 
            ImageUrl="/Photos/SearchIcon.png" Height="20px" Width="20px" 
            onclick="ImageButton12_Click"/>
        &nbsp;<asp:TextBox ID="TextBox8" runat="server" placeholder="Find performance by name" 
            Width="200px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton13" runat="server" 
            ImageUrl="/Photos/SearchIcon.png" Height="20px" onclick="ImageButton13_Click" 
            Width="20px"/>
        <br />
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" class="grids"
            onrowcommand="GridView5_RowCommand" style="font-family: Tahoma; text-align: center;" 
            onrowdeleting="GridView5_RowDeleting">
            <Columns>
                <asp:BoundField DataField="PerformanceId" HeaderText="Performance Id" 
                    SortExpression="PerformanceId" />
                <asp:BoundField DataField="PerformanceName" HeaderText="Performance Name" 
                    SortExpression="PerformanceName" />
                <asp:BoundField DataField="PerformanceLength" HeaderText="Performance Length" 
                    SortExpression="PerformanceLength" />
                <asp:ImageField DataImageUrlField="PerformancePhoto" 
                    HeaderText="Performance Photo">
                    <ControlStyle Height="50px" Width="50px" />
                    <ItemStyle Height="50px" Width="50px" />
                </asp:ImageField>
                <asp:ButtonField ButtonType="Button" CommandName="Confirm" HeaderText="Confirm" 
                    ShowHeader="True" Text="Confirm" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" 
                    ShowHeader="True" Text="Delete" />
            </Columns>
        </asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>
