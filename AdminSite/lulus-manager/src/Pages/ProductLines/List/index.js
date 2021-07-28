import { Table, Space,Button } from 'antd';
import React, { Component } from 'react';
import './index.css';
import {Post} from '../../../HttpHelper/HttpHelper';
import {ConvertResources} from '../../../HttpHelper/GetResourceHelper'
import {withRouter} from 'react-router-dom';

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
                title: 'Created at',
                dataIndex: 'createdDate',
                key: 'createdDate',
              },
              {
                title: 'Updated at',
                dataIndex: 'updatedDate',
                key: 'updatedDate',
              },
            {
            title: 'Texture name',
            dataIndex: 'texture_Name',
            key: 'texture_Name',
          },
          {
            title: 'Texture image',
            key: 'texture_Image',
            render:(text,record) =>(
                <img src={ConvertResources(record.texture_Image_Url)} alt={record.texture_Name}/>
            )
          },
          {
            title: 'Action',
            key: 'action',
            render: (text, record) => (
                <Space size="middle">
                    <p className= "actionBtn">Detail</p>
                    <p className= "actionBtn" onClick={()=>this.editProductLine(record.id)}>Edit</p>
                    <p className= "actionBtn" onClick={()=>this.deleteSubCate(record.id)}>Delete</p>
                </Space>
              ),
          },
        ]
        var result = await Post(this.props.token,'/ManageProductLine/GetAllLinesByID',{
            "productID": this.props.match.params.id
          })
        if(result.status === 200){
            this.state.dataSource = result.data;
            this.setState(this);
        }
        this.setState(this);

    }
    deleteSubCate(key){
        // Check key have products, if not allow delete
    }
    goBackPrevious(){
        this.props.history.goBack();
    }
    editProductLine(id){
        this.props.history.push('/manageProductLine/'+id);
    }
    createProductLine(){
        this.props.history.push('/manageProductLine');
    }
    render() {
        return (
            <div>
                <Button type="primary" shape="round" className="btnPosition" onClick={()=>this.createProductLine()}>
                    Add product line +
                </Button>
                <Table dataSource={this.state.dataSource} columns = {this.state.columns}/>
                <Button type="primary" shape="round" onClick={()=>this.goBackPrevious()} className="btnPosition">Go back</Button>
            </div>
        )
    }
}

export default withRouter(ListProductLines)
