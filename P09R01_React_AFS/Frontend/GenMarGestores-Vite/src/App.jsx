import React ,{ useState,useEffect } from 'react'
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { Modal,ModalBody,ModalFooter,ModalHeader } from 'reactstrap';

//const baseUrl = ${import.meta.env.VITE_API_URL}/gestores

function App() {
  const baseUrl="https://localhost:7118/api/Gestores";
  //para controlar cuando se abren y cuando se cierra los modales
  const [data,setData]=useState([]);
  const [modalInsertar,setModalInsertar]= useState(false);
  const [modalEditar,setModalEditar]= useState(false);

  const [modalEliminar,setModalEliminar]= useState(false);
//metodo que utiliza hooks porque usa el usestate
  const [gestorSeleccionado,setGestorSeleccionado]=useState({
    id:'',
    nombre:'',
    lanzamiento:'',
    desarrollador:''
  })

  const handlChange = e =>{
    const {name,value}=e.target;
    setGestorSeleccionado({
      ...gestorSeleccionado,
      [name]:value
    });
    console.log(gestorSeleccionado);
  };

  const abrirCerrarModalInsertar=()=>{
    setModalInsertar(!modalInsertar);
  }
  const abrirCerrarModalEditar=()=>{
    setModalEditar(!modalEditar);
  }

  const abrirCerrarModalEliminar=()=>{
    setModalEliminar(!modalEliminar);
  }
    const peticionGet=async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

const peticionPost = async () =>{
  try {
    const nuevoGestor = {
      nombre: gestorSeleccionado.nombre,
      desarrollador: gestorSeleccionado.desarrollador,
      lanzamiento: gestorSeleccionado.lanzamiento
      ? parseInt(gestorSeleccionado.lanzamiento)
      : 0
    };
    console.log("Enviado a la API:", nuevoGestor);
    
    const response = await axios.post(baseUrl, nuevoGestor, {
      headers: { "Content-Type": "application/json"}
    });

    setData ([...data, response.data]);
    abrirCerrarModalInsertar();

  }
  catch (error){
    console.error("Error al insertar:",error);
    if(error.response){
      console.error("❤ Respuestas de servidor:", error.response.data);
    }
  }
};

const peticionPut= async()=>{
  gestorSeleccionado.lanzamiento=parseInt(gestorSeleccionado.lanzamiento);
  await axios.put(baseUrl+"/"+gestorSeleccionado.id, gestorSeleccionado)
  .then (response=>{
    var respuesta=response.data;
    var dataAuxiliar=data;
    dataAuxiliar.map(gestor=>{
      if(gestor.id===gestorSeleccionado.id){
        gestor.nombre=respuesta.nombre;
        gestor.lanzamiento=respuesta.lanzamiento;
        gestor.desarrollador=respuesta.desarrollador;
      }
    })
    abrirCerrarModalEditar();
  }).catch(error=>{
    console.log(error);
  })
}


const peticionDelete=async()=>{
  await axios.delete(baseUrl+"/"+gestorSeleccionado.id)
  .then(response=>{
    setData(data.filter(gestor=>gestor.id!==response.data));
    abrirCerrarModalEliminar();
  }).catch(error=>{
    console.log(error);
  })
}

const seleccionarGestor=(gestor, caso)=>{
  setGestorSeleccionado(gestor);
  (caso === "Editar")?
  abrirCerrarModalEditar():abrirCerrarModalEliminar();
}

useEffect(()=>{
  peticionGet();
},[])

return (
  <div className="App">
    <br/><br/>
    <button onClick={()=>abrirCerrarModalInsertar()} className="btn btn-succes">Insertar nuevo Gestor</button>
    <br/><br/>
    <table className="table table-bodered">
      <thead>
        <tr>
          <th>ID</th>
          <th>Nombre</th>
          <th>Lanzamiento</th>
          <th>Desarrollador</th>
          <th>Acciones</th>
        </tr>
      </thead>

      <tbody>
        {data.map(gestor=>(
          <tr key={gestor.id}>
            <td>{gestor.id}</td>
            <td>{gestor.nombre}</td>
            <td>{gestor.lanzamiento}</td>
            <td>{gestor.desarrollador}</td>
            <td>
              <button className="btn btn-primary" onClick={()=>seleccionarGestor(gestor,"Editar")}>Editar</button>{" "}
              <button className="btn btn-danger" onClick={()=>seleccionarGestor(gestor,"Eliminar")}>Eliminar</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>

      <Modal isOpen={modalInsertar}>
        <ModalHeader>Insertar Gestor de Bse de Datos</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Nombre:</label>
            <br />
            <input type="text" className="form-control" name='nombre' onChange={handlChange}/>
            <label>Lanzamiento:</label>
            <br />
            <input type="text" className="form-control" name='lanzamiento' onChange={handlChange}/>
            <label>Desarrollador:</label>
            <br />
            <input type="text" className="form-control" name='desarrollador' onChange={handlChange}/>
            
          </div>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-primary" onClick={()=>peticionPost()}>Insertar</button>{" "}
          <button className="btn btn-primary" onClick={()=>abrirCerrarModalInsertar()}>Cancelar</button>
        </ModalFooter>
      </Modal>



        <Modal isOpen={modalEditar}>
        <ModalHeader>Editar Gestor de Bse de Datos</ModalHeader>
        <ModalBody>
          <div className="form-group">
             <label>ID:</label>
            <br />
            <input type="text" className="form-control" readOnly value={gestorSeleccionado && gestorSeleccionado.id}/>

            <label>Nombre:</label>
            <br />
            <input type="text" className="form-control" name='nombre' onChange={handlChange} value={gestorSeleccionado && gestorSeleccionado.name} />
            <label>Lanzamiento:</label>
            <br />
            <input type="text" className="form-control" name='lanzamiento' onChange={handlChange} value={gestorSeleccionado && gestorSeleccionado.lanzamiento}/>
            <label>Desarrollador:</label>
            <br />
            <input type="text" className="form-control" name='desarrollador' onChange={handlChange} value={gestorSeleccionado && gestorSeleccionado.desarrollador}/>
            
          </div>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-primary" onClick={()=>peticionPut()}>Editar</button>{" "}
          <button className="btn btn-primary" onClick={()=>abrirCerrarModalEditar()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      

      
        <Modal isOpen={modalEliminar}>
          <ModalBody>
            Estas seguro de eliminar el Gestor {gestorSeleccionado && gestorSeleccionado.nombre}?
          </ModalBody>
          <ModalFooter>
            <button className="btn btn-danger" onClick={()=>peticionDelete()}>
              SI
            </button>
            <button className="btn btn-secondary" onClick={()=>abrirCerrarModalEliminar()}>
              NO
            </button>
          </ModalFooter>
        </Modal>
  </div>
);
}
export default App;