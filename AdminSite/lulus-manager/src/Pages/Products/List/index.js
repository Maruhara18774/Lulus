import { Table, Space,Button } from 'antd';
import React, { Component } from 'react';
import './index.css';
import SampleProduct from '../../../sample-data/product.json';
import {withRouter} from 'react-router-dom';

export class ListProducts extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             dataSource: SampleProduct,
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
            title: 'Sale Price',
            dataIndex: 'salePrice',
            key: 'salePrice',
          },
          {
            title: 'Number of lines',
            key: 'line',
            render:(text,record)=>(
              <p>{record.listProductLines.length}</p>
            )
          },
          {
            title: 'Action',
            key: 'action',
            render: (text, record) => (
                <Space size="middle">
                    <p className= "actionBtn">List productlines</p>
                    <p className= "actionBtn" onClick={()=>this.editProduct(record.id)}>Edit</p>
                    <p className= "actionBtn" onClick={()=>this.deleteSubCate(record.id)}>Delete</p>
                </Space>
              ),
          },
        ]
        this.setState(this);
    }
    createProduct(){
        this.props.history.push("/manageProduct");
    }
    editProduct(id){
      this.props.history.push("/manageProduct/"+id);
    }
    deleteSubCate(key){
        // Check key have product line and order of product line, if not allow delete
    }
    render() {
        return (
            <div>
                <Button type="primary" shape="round" className="btnPosition" onClick = {()=>this.createProduct()}>
                    New Product +
                </Button>
                <Table dataSource={this.state.dataSource} columns = {this.state.columns}/>
            </div>
        )
    }
}

export default withRouter(ListProducts)
