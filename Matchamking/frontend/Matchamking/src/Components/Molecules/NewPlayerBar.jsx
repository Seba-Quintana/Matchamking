import React from 'react'
import SearchBox from '../Atoms/SearchBox'
import HeaderText from '../Atoms/HeaderText'
import InputFieldPlayername from '../Atoms/InputFieldPlayername'


const NewPlayerBar = (setPlayername) => {
  return (
    <>
        <HeaderText text='Crear un nuevo jugador'></HeaderText>
        <InputFieldPlayername text='Introducir un nombre' setPlayername={setPlayername}></InputFieldPlayername>
    </>
  )
}

export default NewPlayerBar