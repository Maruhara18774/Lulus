import { Table, Space,Button } from 'antd';
import React, { Component } from 'react';
import './index.css';

export class ListProductLines extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
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
            title: 'Sub-category name',
            dataIndex: 'name',
            key: 'name',
          },
          {
            title: 'Action',
            key: 'action',
            render: (text, record) => (
                <Space size="middle">
                    <a>Edit</a>
                    <a onClick={()=>this.deleteSubCate(record.id)}>Delete</a>
                </Space>
              ),
          },
        ]
    }
    deleteSubCate(key){
        // Check key have products, if not allow delete
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

export default ListProductLines
