import PopupStyle from "../Atoms/PopupStyle";
import React from 'react'
import { useEffect } from "react";

const PopupPlayerCreation = (props) => {

    if(props.requested === true)
    {
        if(props.requestState === -1)
        {
            return(
                <PopupStyle text='Hubo un error al crear el jugador. 
                O bien ese nombre ya existe o no cumple los requisitos para nombres.'
                setRequested={props.setRequested}
                requestState={props.requestState}
                ></PopupStyle>
            )
        }
        return(
            <PopupStyle text='El jugador ha sido creado correctamente'
            setRequested={props.setRequested}
            requestState={props.requestState}
            ></PopupStyle> 
        )
    }

  return (
    <></>
  )
}

export default PopupPlayerCreation