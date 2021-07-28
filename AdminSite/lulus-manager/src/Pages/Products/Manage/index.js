import React, { Component } from 'react';
import './index.css';
import { Form, Input, Button, Typography, Select } from 'antd';
import {withRouter} from 'react-router-dom';
import {Get,Post} from '../../../HttpHelper/HttpHelper';
const {Title} = Typography;
const {Option} = Select;

export class ManageProduct extends Component {
    constructor(props) {
        super(props);
        this.state = {
             isCreate: (this.props.match.params.id === undefined),
             lsCategory: [],
             lsSubCategory:[]
        }
    }
    goPreviousPage(){
        this.props.history.goBack();
    }
    async componentDidMount(){
        const result = await Get(this.props.token,'/Category');
        if(result.status === 200){
          this.state.lsCategory = result.data;
        }
        this.setState(this);
    }
    onCategoryChange = async (val) =>{
        const result = await Post(this.props.token,'/SubCategory/GetList',{
            categoryID: val
        });
        if(result.status === 200){
          this.state.lsSubCategory = result.data;
        }
        this.setState(this);
    }
    createProduct = async (val) =>{
        const result = await Post(this.props.token,'/ManageProduct/Create',{
            "name": val.name,
            "price": val.price,
            "salePrice": val.saleprice,
            "description": val.description,
            "subCategoryID": val.subcategory
          });
        if(result.status === 200){
          alert("Added success.");
          this.goPreviousPage();
        }
        else{
            alert("Added fail.")
        }
    }
    editProduct = async (val) =>{
        const checkSalePrice = val.saleprice === 0 || val.saleprice === undefined? val.price: val.saleprice;
        const result = await Post(this.props.token,'/ManageProduct/Update',{
            "id":this.props.match.params.id,
            "name": val.name,
            "price": val.price,
            "salePrice": checkSalePrice,
            "description": val.description,
            "subCategoryID": val.subcategory,
            "status": 0
          });
        if(result.status === 200){
          alert("Edited success.");
          this.goPreviousPage();
        }
        else{
            alert("Edited fail.")
        }
    }
    submitHandler = (val) =>{
        if(this.state.isCreate){
            this.createProduct(val);
        }
        else{
            this.editProduct(val);
        }
    }
    render() {
        return (
            <div className="wrap">
                <Form
                    name="basic"
                    initialValues={{ remember: true }}
                    onFinish={this.submitHandler}
                >
                    <Form.Item>
                        {this.state.isCreate?<Title>Create Product</Title>:<Title>Edit Product</Title>}
                    </Form.Item>
                    <Form.Item
                        label="Product's name:"
                        name="name"
                        rules={[{ required: true, message: "Please input Product's name!" }]}
                    >
                        <Input className="custom-input"/>
                    </Form.Item>
                    <Form.Item name="category" label="Category:" rules={[{ required: true }]}>
                        <Select
                            placeholder="Select a Category"
                            onChange={this.onCategoryChange}
                            allowClear
                        >
                            {this.state.lsCategory.map((val,key)=>{
                                return(<Option value={val.id}>{val.name}</Option>)
                            })}
                        </Select>
                    </Form.Item>
                    <Form.Item name="subcategory" label="Subcategory:" rules={[{ required: true }]}>
                        <Select
                            placeholder="Select a Subcategory"
                            onChange={this.onCategoryChange}
                            allowClear
                        >
                            {this.state.lsSubCategory.map((val,key)=>{
                                return(<Option value={val.id}>{val.name}</Option>)
                            })}
                        </Select>
                    </Form.Item>
                    <Form.Item
                        label="Product's price:"
                        name="price"
                        rules={[{ required: true, message: "Please input Product's price!" }]}
                    >
                        <Input className="custom-input" type="number"/>
                    </Form.Item>
                    <Form.Item
                        label="Product's sale price:"
                        name="saleprice"
                    >
                        <Input className="custom-input" type="number"/>
                    </Form.Item>
                    <Form.Item
                        label="Product's description:"
                        name="description"
                    >
                        <Input.TextArea className="custom-input"/>
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

export default withRouter(ManageProduct);
