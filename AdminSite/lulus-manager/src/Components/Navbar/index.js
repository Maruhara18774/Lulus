import React, { Component } from 'react';
import './index.css';
import { Menu, Button } from 'antd';
import { AppstoreOutlined, DoubleRightOutlined, DoubleLeftOutlined,LineChartOutlined,UserOutlined } from '@ant-design/icons';
import logoUrl from '../../Assets/logo/logo.png';

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
    render() {
        if(!this.state.minimize){
            return (
                <Menu
                    onClick={e => this.handleClick(e)}
                    style={{height:"100%"}}
                    mode="inline"
                >
                    <img src={logoUrl} alt="Lulus Logo" height="50" className="header-logo"/>
                    <Button danger className="header-logout" onClick={()=>this.logout()}>Logout</Button>
                    <SubMenu key="common" icon={<AppstoreOutlined />} title="General management">
                        <Menu.ItemGroup key="category" title="Categories">
                            <Menu.Item key="listCategory">List categories</Menu.Item>
                            <Menu.Item key="createCategory">Create new category</Menu.Item>
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
                    <p onClick={()=>this.changeMinimize()} className="header-button"><DoubleLeftOutlined/> Thu nhỏ </p>
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
                </Menu>
            )
        }
    }
}

export default Navbar
