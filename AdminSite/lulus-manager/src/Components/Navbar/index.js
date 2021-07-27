import React, { Component } from 'react';
import './index.css';
import { Menu} from 'antd';
import { AppstoreOutlined, DoubleRightOutlined, LineChartOutlined,UserOutlined,LockOutlined } from '@ant-design/icons';
import logoUrl from '../../Assets/logo/logo.png';
import { Link } from 'react-router-dom';
import { withRouter } from "react-router-dom";

const { SubMenu } = Menu;
export class Navbar extends Component {
    constructor(props) {
        super(props)

        this.state = {
            minimize: false
        }
    }
    changeMinimize = async () => {
        const currentState = this.state.minimize;
        await this.setState({ minimize: !currentState });
    }
    logout = () => {
        this.props.callback();
    }
    handleClick(e){
        switch(e.key){
            // Category
            case "listCategory":
                this.props.history.push("/listCategory");
                break;
            case "createCategory":
                break;

            // Product
            case "listProduct":
                break;
            case "createProduct":
                break;

            // User
            case "listCustomer":
                break;
            case "listAdmin":
                break;
            case "createAdmin":
                break;

            // Statistic
            case "statistic":
                break;

            // Your account
            case "infor":
                break;
            case "changePassword":
                break;
            case "logout":
                this.logout();
                break;

            // Custom workspace
            case "theme":
                break;
            case "minimize":
                this.changeMinimize();
                break;
            
            default:
                break;
        }
    }
    render() {
        if(!this.state.minimize){
            return (
                <Menu
                    onClick={e => this.handleClick(e)}
                    style={{height:"100%"}}
                    mode="inline"
                >
                    <Link to="/">
                    <img src={logoUrl} alt="Lulus Logo" height="50" className="header-logo" onClick={() => this.handleClick("home")}/>
                    </Link>
                    
                    <SubMenu key="common" icon={<AppstoreOutlined />} title="General management">
                        <Menu.ItemGroup key="category" title="Categories">
                            <Menu.Item key="listCategory">List categories</Menu.Item>
                            <Menu.Item key="createCategory">Create new subcategory</Menu.Item>
                        </Menu.ItemGroup>
                        <Menu.ItemGroup key="product" title="Products">
                            <Menu.Item key="listProduct">List products</Menu.Item>
                            <Menu.Item key="createProduct">Create new product</Menu.Item>
                        </Menu.ItemGroup>
                    </SubMenu>
                    <SubMenu key="user" icon={<UserOutlined />} title="User">
                        <Menu.ItemGroup key="customer" title="Customers">
                            <Menu.Item key="listCustomer">List customers</Menu.Item>
                        </Menu.ItemGroup>
                        <Menu.ItemGroup key="admin" title="Moderators">
                            <Menu.Item key="listAdmin">List accounts</Menu.Item>
                            <Menu.Item key="createAdmin">Create new account</Menu.Item>
                        </Menu.ItemGroup>
                    </SubMenu>
                    <SubMenu key="report" icon={<LineChartOutlined />} title="Report">
                        <Menu.Item key="statistic">Statistic</Menu.Item>
                    </SubMenu>
                    <SubMenu key="yours" icon={<LockOutlined />} title="Your account">
                        <Menu.Item key="infor">Information</Menu.Item>
                        <Menu.Item key="changePassword">Change password</Menu.Item>
                        <Menu.Item key="logout">Logout</Menu.Item>
                    </SubMenu>
                    <SubMenu key="custom" icon={<LockOutlined />} title="Custom workspace">
                        <Menu.Item key="theme">Theme</Menu.Item>
                        <Menu.Item key="minimize">Minimize</Menu.Item>
                    </SubMenu>
                </Menu>
            )
        }
        else{
            return (
                <Menu
                    onClick={() => this.changeMinimize()}
                    style={{ width: 80, height:"100%" }}
                    mode="inline"
                >
                    <div style= {{marginTop:"20px", marginLeft:"40%"}}>
                        <DoubleRightOutlined onClick={()=>this.changeMinimize()}/>
                    </div>
                    <SubMenu key="common" icon={<AppstoreOutlined />} title="General management">
                        <Menu.ItemGroup key="category">
                            <Menu.Item key="listCategory">List categories</Menu.Item>
                            <Menu.Item key="createCategory">Create new category</Menu.Item>
                        </Menu.ItemGroup>
                        <Menu.ItemGroup key="product">
                            <Menu.Item key="listProduct">List products</Menu.Item>
                            <Menu.Item key="createProduct">Create new product</Menu.Item>
                        </Menu.ItemGroup>
                    </SubMenu>
                    <SubMenu key="user" icon={<UserOutlined />} title="User">
                        <Menu.ItemGroup key="customer">
                            <Menu.Item key="listCustomer">List customers</Menu.Item>
                        </Menu.ItemGroup>
                        <Menu.ItemGroup key="admin">
                            <Menu.Item key="listAdmin">List accounts</Menu.Item>
                            <Menu.Item key="createAdmin">Create new account</Menu.Item>
                        </Menu.ItemGroup>
                    </SubMenu>
                    <SubMenu key="report" icon={<LineChartOutlined />} title="Report">
                        <Menu.Item key="statistic">Statistic</Menu.Item>
                    </SubMenu>
                    <SubMenu key="yours" icon={<LockOutlined />} title="Your account">
                        <Menu.Item key="infor">Information</Menu.Item>
                        <Menu.Item key="changePassword">Change password</Menu.Item>
                        <Menu.Item key="logout">Logout</Menu.Item>
                    </SubMenu>
                </Menu>
            )
        }
    }
}

export default withRouter(Navbar)
