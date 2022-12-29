import React from 'react'
import BackArrow from '../Components/Atoms/BackArrow'
import TextBox from '../Components/Atoms/TextBox'
import NewPlayerBar from '../Components/Molecules/NewPlayerBar'
import CreatePlayerBtn from '../Components/Atoms/CreatePlayerBtn'

const AddPlayer = () => {
  return (
    <>
      <BackArrow navigate='/'></BackArrow>
      <NewPlayerBar></NewPlayerBar>
      <CreatePlayerBtn></CreatePlayerBtn>
      <TextBox text='
      El nickname puede únicamente contener letras, números, 
      ciertos caracteres especiales (-, _, !), y debe tener una longitud
      de 4 a 20 letras.
      El nickname se muestra al momento de ver los rankings,
      estadísticas y pickear jugadores. 
      '></TextBox>
    </>
  )
}

export default AddPlayer