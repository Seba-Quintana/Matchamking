import React from 'react'
import SearchBox from '../Atoms/SearchBox'
import HeaderText from '../Atoms/HeaderText'
import InputFieldPlayername from '../Atoms/InputFieldPlayername'


const NewPlayerBar = (playername, setPlayername) => {
  return (
    <>
        <HeaderText text='Crear un nuevo jugador'></HeaderText>
        <InputFieldPlayername text='Introducir un nombre' playername={playername} setPlayername={setPlayername}></InputFieldPlayername>
    </>
  )
}

export default NewPlayerBar