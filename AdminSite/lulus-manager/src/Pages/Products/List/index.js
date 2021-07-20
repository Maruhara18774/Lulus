import { Table, Space,Button } from 'antd';
import React, { Component } from 'react';
import './index.css';

export class ListProducts extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             lsProduct: [],
             dataSource: [],
             columns: []
        }
    }
    async componentDidMount(){
        this.state.columns = [
            {
                title: 'ID',
                dataIndex: 'id',
                key: 'id',
              },
            {
            title: 'Product name',
            dataIndex: 'name',
            key: 'name',
          },
          {
            title: 'Price',
            dataIndex: 'price',
            key: 'price',
          },
          {
            title: 'Category',
            dataIndex: 'category',
            key: 'category',
          },
          {
            title: 'Sub-category',
            dataIndex: 'subcategory',
            key: 'subcategory',
          },
          {
            title: 'Action',
            key: 'action',
            render: (text, record) => (
                <Space size="middle">
                    <a>List productlines</a>
                    <a>Edit</a>
                    <a onClick={()=>this.deleteSubCate(record.id)}>Delete</a>
                </Space>
              ),
          },
        ]
    }
    deleteSubCate(key){
        // Check key have product line and order of product line, if not allow delete
    }
    render() {
        return (
            <div>
                <Button type="primary" shape="circle">
                    +
                </Button>
                <Table dataSource={this.state.dataSource} columns = {this.state.columns}/>
            </div>
        )
    }
}

export default ListProducts
