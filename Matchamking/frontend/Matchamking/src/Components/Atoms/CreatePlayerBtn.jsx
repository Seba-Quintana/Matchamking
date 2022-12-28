import React from 'react'
import styled from 'styled-components'
import MiddleButtonStyle from './MiddleButtonStyle'

const Button = styled(MiddleButtonStyle)`
    margin-top: 1rem;
`
const Text = styled.div`
    font-family: 'Inter', sans-serif;
    color: white;
    margin-right: 1rem;
`

const CreatePlayerBtn = () => {
  return (
    <Button>
        <Text>
            Crear
        </Text>
    </Button>
  )
}

export default CreatePlayerBtn