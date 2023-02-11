import React from 'react'
import BackArrow from '../Components/Atoms/BackArrow'
import TextBox from '../Components/Atoms/TextBox'
import NewPlayerBar from '../Components/Molecules/NewPlayerBar'
import CreatePlayerBtn from '../Components/Atoms/CreatePlayerBtn'
import { useState } from 'react'
import { useEffect } from 'react'
import PopupStyle from '../Components/Atoms/PopupStyle'
import PopupPlayerCreation from '../Components/Molecules/PopupPlayerCreation'

const AddPlayer = () => {

  const [playername, setPlayername] = useState('')
  const [requested, setRequested] = useState(false)
  const [requestState, setRequestState] = useState(-1)

  const newPlayerReq = () => {
    console.log('You clicked me!')
    if(playername != '')
    {
      console.log('And I have data!')
      fetch('http://localhost:5071/api/players?' + 'name=' + playername, 
      {
        method: 'POST'
      }).then((res) => {
        if(res.ok)
        {
          setRequestState(0)
        }
        else
        {
          setRequestState(-1)
        }
      }).then(
        setRequested(true)
      )
      console.log(requested)
    }
    else
    {
      console.log('But I have no data...')
      setRequestState(-1)
      setRequested(true) 
    }

  }

  useEffect(() => 
    {console.log(playername)},
   [playername])
  return (
    <>
      <BackArrow navigate='/'></BackArrow>
      <NewPlayerBar playername={playername} setPlayername={setPlayername}></NewPlayerBar>
      <CreatePlayerBtn onClick={newPlayerReq}></CreatePlayerBtn>
      <PopupPlayerCreation requested={requested} setRequested={setRequested} requestState={requestState}></PopupPlayerCreation>
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