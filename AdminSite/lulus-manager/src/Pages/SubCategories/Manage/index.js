import React, { Component } from 'react';
import './index.css';
import { Form, Input, Button, Typography, Select  } from 'antd';
import {withRouter} from 'react-router-dom';
import {Get,Post} from '../../../HttpHelper/HttpHelper';
const {Title} = Typography;
const {Option} = Select;

export class ManageSubCategory extends Component {
    constructor(props) {
        super(props);
        this.state = {
            lsCategory: [],
             isCreate: (this.props.match.params.id == undefined),
             defaultCate: {},
             defaultName: ""
        }
        if(!this.state.isCreate){
            this.getSubCateDetail();
        }
    }
    async componentDidMount(){
        var result = await Get(this.props.token,'/Category');
        if(result.status == 200){
            this.state.lsCategory = result.data;
        }
        this.setState(this);
    }
    getSubCateDetail= async () =>{
        var result = await Post(this.props.token,'/ManageSubCategory/GetSubCateDetailByID',{
            "id": this.props.match.params.id,
          })
        if(result.status == 200){
            console.log(result.data)
            this.state.defaultCate = result.data.category;
            this.state.defaultName = result.data.name;
            await this.setState(this);
        }
    }
    goPreviousPage(){
        this.props.history.goBack();
    }
    async createSubCategory(val){
        var result = await Post(this.props.token,'/ManageSubCategory/CreateSubCategory',{
            "categoryID": val.category,
            "name": val.name
          })
        if(result.status == 200){
            alert('Added success.');
            this.goPreviousPage();
        }
        else{
            alert('Added fail.')
        }
    }
    async EditSubCategory(val){
        var result = await Post(this.props.token,'/ManageSubCategory/EditSubCategory',{
            "id": this.props.match.params.id,
            "categoryID": val.category,
            "name": val.name
          })
          if(result.status == 200){
            alert('Edited success.');
            this.goPreviousPage();
        }
        else{
            alert('Edited fail.')
        }
    }
    submitHandler = (value)=> {
        if(this.state.isCreate){
            this.createSubCategory(value);
        }
        else{
            this.EditSubCategory(value);
        }
    }
    render() {
        return (
            <div className="wrap">
                <Form
                    name="basic"
                    onFinish={this.submitHandler}
                >
                    <Form.Item>
                        {this.state.isCreate?<Title>Create Subcategory</Title>:<Title>Edit Subcategory</Title>}
                    </Form.Item>
                    <Form.Item name="category" label="Category:" rules={[{ required: true }]}>
                        <Select
                            placeholder="Select a Category"
                            allowClear
                        >
                            {this.state.lsCategory.map((val,key)=>{
                                return(
                                <Option value={val.id}>{val.name}</Option>
                                )
                            })}
                        </Select>
                    </Form.Item>
                    <Form.Item
                        label="Subcategory's name:"
                        name="name"
                        rules={[{ required: true, message: 'Please input Subcategory name!' }]}
                    >
                        <Input className="custom-input"/>
                    </Form.Item>
                    <Form.Item wrapperCol={{ offset: 10, span: 16 }}>
                        {this.state.isCreate?
                        <Button type="primary" htmlType="submit">Create</Button>:
                        <Button type="primary" htmlType="submit">Save</Button>}
                        <Button type="primary" style={{marginLeft:"10px"}} onClick={()=>this.goPreviousPage()}>Go back</Button>
                    </Form.Item>
                </Form>
            </div>
        )
    }
}

export default withRouter(ManageSubCategory);
