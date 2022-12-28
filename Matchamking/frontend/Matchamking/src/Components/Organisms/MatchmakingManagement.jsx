import React, { useEffect } from 'react'
import ResultsContainer from '../Atoms/ResultsContainer'
import PlayerSearchBar from '../Molecules/PlayerSearchBar'
import PlayerSelect from '../Molecules/PlayerResults'
import { useState } from 'react'
import PlayerResults from '../Molecules/PlayerResults'
import Box from '../Atoms/Box'
import PlayersSelected from '../Molecules/PlayersSelected'
import styled from 'styled-components'

const StyledResultsContainer = styled.div`
  background-color: white;
  width: 90%;
  height: 70%;
  align-items: center;
  flex-direction: column;
  margin-top: 1rem;
  margin-bottom: 1rem;
  border-radius: 5px;
  max-width: 500px;
  overflow-y: auto;
  max-height: 350px;
`
const StyledBox = styled.div`
  width: 100%;
  height: 45px;
  color: gray;
  font-family: 'Inter', sans-serif;
  font-size: medium;
  display: flex;
  justify-content: center;
  align-items: center;
`


const MatchmakingManagement = () => {

  const [players, setPlayers] = useState([])
  const [remainingPlayers, setRemainingPlayers] = useState([])
  const [selectedPlayers, setSelectedPlayers] = useState([])
  const [searchValue, setSearchValue] = useState("")
  const [searchFlag, setSearchFlag] = useState(0)
  const playersList = [
    {
        position: 1,
        playername: 'Diekkan',
        winrate: '100%',
        played: 12,
        state: 0,
    },
    {
        position: 1,
        playername: 'Emiliardo',
        winrate: '100%',
        played: 12,
        state: 0,
    },
    {
        position: 2,
        playername: 'Goku',
        winrate: '80%',
        played: 12,
        state: -1,
    },
    {
        position: 3,
        playername: 'Seba',
        winrate: '70%',
        played: 12,
        state: 3,
    },
    {
        position: 4,
        playername: 'Nitram',
        winrate: '70%',
        played: 12,
        state: 3,
    },
    {
        position: 5,
        playername: 'Juanma',
        winrate: '70%',
        played: 12,
        state: 3,
    },
    {
        position: 6,
        playername: 'Nachoto',
        winrate: '70%',
        played: 12,
        state: 3,
    },
]

  useEffect(() => {
  setRemainingPlayers(playersList);
  setPlayers(playersList);
  }, [])

  useEffect(() => {

    let newArr;

    if (searchValue.length == 0)
    {
      newArr = playersList.filter((player) => 
      !selectedPlayers.some(selectedPlayer => selectedPlayer.playername === player.playername))
      setRemainingPlayers(newArr)
      console.log(newArr)
      setSearchFlag(0)
    }
    else
    {
      newArr = remainingPlayers.filter((player) => player.playername.includes(searchValue))
      setRemainingPlayers(newArr)
      if (newArr.length === 0)
      {
        setSearchFlag(-1)
      }
      console.log(newArr.lenght)
      console.log(searchFlag)
    }
    }, [searchValue])

  return (
    <>
        <PlayerSearchBar setSearchValue={setSearchValue}></PlayerSearchBar>
        <StyledResultsContainer>
          <PlayersSelected 
            selectedPlayers={selectedPlayers}
            setSelectedPlayers={setSelectedPlayers}
            remainingPlayers={remainingPlayers}
            setRemainingPlayers={setRemainingPlayers}
          ></PlayersSelected>
          {
            searchFlag === -1 ?
              <StyledBox>
                No hay resultados
              </StyledBox>
            :
            <PlayerResults
            selectedPlayers={selectedPlayers}
            setSelectedPlayers={setSelectedPlayers}
            remainingPlayers={remainingPlayers}
            setRemainingPlayers={setRemainingPlayers}
          ></PlayerResults>
          }
        </StyledResultsContainer>
    </>
    )
}

export default MatchmakingManagement