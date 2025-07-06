"use client"

import { useChat } from "ai/react"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Badge } from "@/components/ui/badge"
import { MessageCircle, Send, Bot, User } from "lucide-react"

export function HealthChat() {
  const { messages, input, handleInputChange, handleSubmit, isLoading } = useChat({
    api: "/api/health-chat",
    initialMessages: [
      {
        id: "1",
        role: "assistant",
        content:
          "Hello! I'm your AI Health Assistant. I can help you with wellness advice, answer health questions, and provide personalized recommendations based on your health data. How can I assist you today?",
      },
    ],
  })

  const quickQuestions = [
    "How can I improve my sleep quality?",
    "What's a good workout for beginners?",
    "How much water should I drink daily?",
    "Tips for managing stress?",
    "Healthy meal prep ideas?",
  ]

  const handleQuickQuestion = (question: string) => {
    handleSubmit(new Event("submit") as any, { data: { message: question } })
  }

  return (
    <div className="grid grid-cols-1 lg:grid-cols-4 gap-6">
      <div className="lg:col-span-3">
        <Card className="h-[600px] flex flex-col">
          <CardHeader>
            <CardTitle className="flex items-center space-x-2">
              <MessageCircle className="h-5 w-5 text-blue-500" />
              <span>AI Health Assistant</span>
            </CardTitle>
          </CardHeader>
          <CardContent className="flex-1 flex flex-col">
            <div className="flex-1 overflow-y-auto space-y-4 mb-4">
              {messages.map((message) => (
                <div key={message.id} className={`flex ${message.role === "user" ? "justify-end" : "justify-start"}`}>
                  <div
                    className={`max-w-[80%] p-3 rounded-lg ${
                      message.role === "user" ? "bg-blue-500 text-white" : "bg-gray-100 text-gray-900"
                    }`}
                  >
                    <div className="flex items-center space-x-2 mb-1">
                      {message.role === "user" ? <User className="h-4 w-4" /> : <Bot className="h-4 w-4" />}
                      <span className="text-xs font-medium">{message.role === "user" ? "You" : "AI Assistant"}</span>
                    </div>
                    <p className="text-sm whitespace-pre-wrap">{message.content}</p>
                  </div>
                </div>
              ))}
              {isLoading && (
                <div className="flex justify-start">
                  <div className="bg-gray-100 text-gray-900 p-3 rounded-lg">
                    <div className="flex items-center space-x-2">
                      <Bot className="h-4 w-4" />
                      <span className="text-xs font-medium">AI Assistant</span>
                    </div>
                    <p className="text-sm mt-1">Thinking...</p>
                  </div>
                </div>
              )}
            </div>
            <form onSubmit={handleSubmit} className="flex space-x-2">
              <Input
                value={input}
                onChange={handleInputChange}
                placeholder="Ask about your health and wellness..."
                className="flex-1"
                disabled={isLoading}
              />
              <Button type="submit" disabled={isLoading}>
                <Send className="h-4 w-4" />
              </Button>
            </form>
          </CardContent>
        </Card>
      </div>

      <div className="space-y-4">
        <Card>
          <CardHeader>
            <CardTitle className="text-lg">Quick Questions</CardTitle>
          </CardHeader>
          <CardContent className="space-y-2">
            {quickQuestions.map((question, index) => (
              <Button
                key={index}
                variant="outline"
                size="sm"
                className="w-full text-left justify-start h-auto p-3 bg-transparent"
                onClick={() => handleQuickQuestion(question)}
                disabled={isLoading}
              >
                <span className="text-xs">{question}</span>
              </Button>
            ))}
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle className="text-lg">Health Status</CardTitle>
          </CardHeader>
          <CardContent className="space-y-3">
            <div className="flex justify-between items-center">
              <span className="text-sm">Overall Score</span>
              <Badge variant="secondary" className="bg-green-100 text-green-800">
                85/100
              </Badge>
            </div>
            <div className="flex justify-between items-center">
              <span className="text-sm">Sleep Quality</span>
              <Badge variant="secondary" className="bg-blue-100 text-blue-800">
                Good
              </Badge>
            </div>
            <div className="flex justify-between items-center">
              <span className="text-sm">Activity Level</span>
              <Badge variant="secondary" className="bg-orange-100 text-orange-800">
                Moderate
              </Badge>
            </div>
            <div className="flex justify-between items-center">
              <span className="text-sm">Stress Level</span>
              <Badge variant="secondary" className="bg-yellow-100 text-yellow-800">
                Low
              </Badge>
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}
