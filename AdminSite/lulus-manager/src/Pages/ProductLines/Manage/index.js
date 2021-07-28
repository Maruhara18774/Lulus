import React, { Component } from 'react';
import './index.css';
import { Form, Input, Button, Typography, Select, Upload} from 'antd';
import { UploadOutlined } from '@ant-design/icons';
import { withRouter } from 'react-router-dom';
import { Post } from '../../../HttpHelper/HttpHelper';
const { Title } = Typography;
const { Option } = Select;

export class ManageProductLine extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isCreate: (this.props.match.params.id === undefined),
            lsProduct: [],
            imageFile: ""
        }
    }
    async componentDidMount() {
        var result = await Post(this.props.token, '/ManageProduct/GetAll', {
            "pageIndex": 1,
            "pageSize": 10000
        });
        if (result.status === 200) {
            this.state.lsProduct = result.data;
        }
        this.setState(this);
    }
    goPreviousPage() {
        this.props.history.goBack();
    }
    onCategoryChange(val) {
        /* Mindset: when choose a category, go load subcate by val
         */
        alert(val);
    }
    create = async (val) => {
        const result = await Post(this.props.token, '/ManageProductLine/CreateProductLine', {
            "productLine_ID": 0,
            "texture_Name": val.name,
            "texture_ImageUrl": "",
            "texture_Image": undefined,
            "product_ID": val.product
        });
        if (result.status === 200) {
            alert("Added success.");
            this.goPreviousPage();
        }
        else {
            alert("Added fail.")
        }
    }
    edit = async (val) =>{

    }
    submitHandler=(val)=>{
        if(this.state.isCreate){
            //this.create(val);
            console.log(val)
        }
        else{
            this.edit(val);
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
                        {this.state.isCreate ? <Title>Create Product Line</Title> : <Title>Edit Product Line</Title>}
                    </Form.Item>
                    <Form.Item
                        label="Texture's name:"
                        name="name"
                        rules={[{ required: true, message: "Please input Texture's name!" }]}
                    >
                        <Input className="custom-input" />
                    </Form.Item>
                    <Form.Item
                        name="upload"
                        label="Upload texture image:"
                        valuePropName="fileList"
                    >
                        <Upload name="logo" listType="picture">
                            <Button icon={<UploadOutlined />}>Click to upload</Button>
                        </Upload>
                    </Form.Item>
                    <Form.Item name="product" label="Product:" rules={[{ required:true, message: "Please choose a Product!" }]}>
                        <Select
                            placeholder="Select a Product"
                            allowClear
                        >
                            {this.state.lsProduct.map((val, key) => {
                                return (<Option value={val.id}>{val.name}</Option>)
                            })}
                        </Select>
                    </Form.Item>
                    <Form.Item wrapperCol={{ offset: 10, span: 16 }}>
                        {this.state.isCreate ?
                            <Button type="primary" htmlType="submit">Create</Button> :
                            <Button type="primary" htmlType="submit">Save</Button>}
                        <Button type="primary" style={{ marginLeft: "10px" }} onClick={() => this.goPreviousPage()}>Go back</Button>
                    </Form.Item>
                </Form>
            </div>
        )
    }
}

export default withRouter(ManageProductLine);
