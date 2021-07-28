import React, { Component } from 'react';
import './index.css';
import { Form, Input, Button, Checkbox, Typography, Select } from 'antd';
import {withRouter} from 'react-router-dom';
import SampleCategory from '../../../sample-data/category.json';
import SampleSubCategory from '../../../sample-data/subcategory.json';
const {Title} = Typography;
const {Option} = Select;

export class ManageProduct extends Component {
    constructor(props) {
        super(props);
        this.state = {
             isCreate: (this.props.match.params.id == undefined),
             lsCategory: SampleCategory,
             lsSubCategory: SampleSubCategory,
             lsAvailableSubCategory: []
        }
    }
    goPreviousPage(){
        this.props.history.goBack();
    }
    onCategoryChange(val){
        /* Mindset: when choose a category, go load subcate by val
         */
        alert(val);
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
                            {this.state.lsAvailableSubCategory.map((val,key)=>{
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
